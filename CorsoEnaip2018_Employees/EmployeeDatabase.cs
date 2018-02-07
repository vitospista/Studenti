using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Employees
{
    public class EmployeeDatabase : ISaver
    {
        private string _connectionString;
        private IDbConnection _connection;

        public EmployeeDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(List<Employee> list)
        {
            _connection = new SqlConnection(_connectionString);

            _connection.Open();

            foreach (var e in list)
            {
                e.Id = saveEmployee(e);

                e.PayCalculator.AcceptSaver(this, e);

                //saveMalusCalculator(e);
            }

            _connection.Close();
        }
        private int saveEmployee(Employee e)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                " INSERT INTO Employees" +
                " (Name,TotalPay,BonusCalculatorType) OUTPUT INSERTED.ID" +
                " VALUES" +
                " (@Name,@TotalPay,@BonusCalculatorType)";

            cmd.Parameters.Add(new SqlParameter("Name", e.Name));
            cmd.Parameters.Add(new SqlParameter("TotalPay", e.TotalPay));
            cmd.Parameters.Add(new SqlParameter("BonusCalculatorType", e.BonusCalculator.GetType().Name));

            int id = (int)cmd.ExecuteScalar();

            return id;
        }
        public void Save(Employee e, FixedPayCalculator c)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                 " UPDATE Employees SET" +
                 " PayCalculatorType = @PayCalculatorType," +
                 " MonthlySalary = @MonthlySalary" +
                 " WHERE Id = @Id;";
            cmd.Parameters.Add(new SqlParameter("PayCalculatorType", c.GetType().Name));
            cmd.Parameters.Add(new SqlParameter("MonthlySalary", c.MonthlySalary));
            cmd.Parameters.Add(new SqlParameter("Id", e.Id));

            cmd.ExecuteNonQuery();
        }
        public void Save(Employee e, HourlyPayCalculator c)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                 " UPDATE Employees SET" +
                 " PayCalculatorType = @PayCalculatorType," +
                 " HourlySalary = @HourlySalary" +
                 " WHERE Id = @Id;";
            cmd.Parameters.Add(new SqlParameter("PayCalculatorType", c.GetType().Name));
            cmd.Parameters.Add(new SqlParameter("HourlySalary", c.HourlySalary));
            cmd.Parameters.Add(new SqlParameter("Id", e.Id));

            cmd.ExecuteNonQuery();

            foreach (var s in c.Hours)
            {
                var schedulationCmd = _connection.CreateCommand();
                schedulationCmd.CommandType = CommandType.Text;
                schedulationCmd.CommandText =
                    " INSERT INTO Schedulations" +
                    " (EmployeeId,Date,WorkedHours)" +
                    " VALUES" +
                    " (@EmployeeId, @Date,@WorkedHours);";

                schedulationCmd.Parameters.Add(new SqlParameter("EmployeeId", e.Id));
                schedulationCmd.Parameters.Add(new SqlParameter("Date", s.Key));
                schedulationCmd.Parameters.Add(new SqlParameter("WorkedHours", s.Value));

                schedulationCmd.ExecuteNonQuery();
            }
        }
        public void Save(Employee e, CommissionPayCalculator c)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                 " UPDATE Employees SET" +
                 " PayCalculatorType = @PayCalculatorType," +
                 " CommissionPercentage = @CommissionPercentage" +
                 " WHERE Id = @Id;";
            cmd.Parameters.Add(new SqlParameter("PayCalculatorType", c.GetType().Name));
            cmd.Parameters.Add(new SqlParameter("CommissionPercentage", c.CommissionPercentage));
            cmd.Parameters.Add(new SqlParameter("Id", e.Id));

            cmd.ExecuteNonQuery();

            foreach (var s in c.Commissions)
            {
                var commissionCmd = _connection.CreateCommand();
                commissionCmd.CommandType = CommandType.Text;
                commissionCmd.CommandText =
                    " INSERT INTO Commissions" +
                    " (EmployeeId,Date,CommissionAmount)" +
                    " VALUES" +
                    " (@EmployeeId, @Date,@CommissionAmount);";

                commissionCmd.Parameters.Add(new SqlParameter("EmployeeId", e.Id));
                commissionCmd.Parameters.Add(new SqlParameter("Date", s.Key));
                commissionCmd.Parameters.Add(new SqlParameter("CommissionAmount", s.Value));

                commissionCmd.ExecuteNonQuery();
            }
        }
        public void Save(Employee e, NullPayCalculator c)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                 " UPDATE Employees SET" +
                 " PayCalculatorType = @PayCalculatorType," +
                 " WHERE Id = @Id;";
            cmd.Parameters.Add(new SqlParameter("PayCalculatorType", c.GetType().Name));
            cmd.Parameters.Add(new SqlParameter("Id", e.Id));

            cmd.ExecuteNonQuery();
        }

        public List<Employee> FindAll()
        {
            _connection = new SqlConnection(_connectionString);

            _connection.Open();

            var cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Employees";

            var reader = cmd.ExecuteReader();

            var list = new List<Employee>();

            while (reader.Read())
            {
                var e = new Employee();

                e.Id = (int)reader["Id"];
                e.Name = (string)reader["Name"];
                e.TotalPay = (decimal)reader["TotalPay"];
                e.BonusCalculator =
                    createBonusCalculator((string)reader["BonusCalculatorType"]);

                var payType = (string)reader["PayCalculatorType"];

                switch (payType)
                {
                    case nameof(FixedPayCalculator):
                        var fixedCalc = new FixedPayCalculator();
                        fixedCalc.MonthlySalary = (decimal)reader["MonthlySalary"];
                        break;
                    case nameof(HourlyPayCalculator):
                        var hourlyCalc = new HourlyPayCalculator();
                        hourlyCalc.HourlySalary = (decimal)reader["HourlySalary"];
                        // TODO: pesca le schedulations di questo employee.
                        break;
                    case nameof(CommissionPayCalculator):
                        var commCalc = new CommissionPayCalculator();
                        commCalc.CommissionPercentage = (decimal)reader["CommissionPercentage"];
                        //TODO: pesca le Commissions di questo Employee
                        break;
                    case nameof(NullPayCalculator):
                        break;
                    default:
                        throw new ArgumentException($"'{payType}' is not a known PayCalculator!");
                }

                list.Add(e);
            }

            _connection.Close();

            return list;
        }

        private BonusCalculator createBonusCalculator(string calculatorName)
        {
            BonusCalculator bonusCalc;

            switch (calculatorName)
            {
                case nameof(BigFamilyBonusCalculator):
                    bonusCalc = new BigFamilyBonusCalculator();
                    break;
                case nameof(LittleFamilyBonusCalculator):
                    bonusCalc = new LittleFamilyBonusCalculator();
                    break;
                case nameof(NoFamilyBonusCalculator):
                    bonusCalc = new NoFamilyBonusCalculator();
                    break;
                case nameof(NullBonusCalculator):
                    bonusCalc = NullBonusCalculator.Instance;
                    break;
                default:
                    throw new ArgumentException("Invalid BonusCalculator");
            }

            return bonusCalc;
        }

        private Dictionary<DateTime, int> getSchedulations(int employeeId)
        {
            throw new NotImplementedException();
        }

        private Dictionary<DateTime, decimal> getCommissions(int employeeId)
        {
            throw new NotImplementedException();
        }
    }

    static class Constants
    {
        public const string EMPLOYEE_TABLE = "Employees";
        public const string EMPLOYEE_NAME_FIELD = "Name";
    }

    public class ConnectionFactory
    {
        public IDbConnection CreateSqlServerConnection()
        {
            // ...
            throw new NotImplementedException();
        }

        public IDbConnection CreateOracleSqlConnection()
        {
            throw new NotImplementedException();
        }
    }

    public interface IConnectionFactory
    {
        IDbConnection CreateSqlServerConnection();
        IDbConnection CreateOracleSqlConnection();
    }

    public class EmployeeApplication
    {
        public IConnectionFactory ConnectionFactory { get; set; }
    }
}
