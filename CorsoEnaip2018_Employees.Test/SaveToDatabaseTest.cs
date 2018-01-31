using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Employees.Test
{
    [TestClass]
    class SaveToDatabaseTest
    {
        [TestMethod]
        public void SaveAndGet()
        {
            // creo lista di Employee con Pay/Bonus/Malus diversi.
            var list = createEmployees();

            var conn = new SqlConnection(@"Data Source=TRISRV10\SQLEXPRESS;Initial Catalog=CorsoEuris_Kraus;Integrated Security=True");

            conn.Open();

            foreach(var e in list)
            {

                

                if (e.PayCalculator.GetType() == typeof(FixedPayCalculator))
                {
                }
                else if (e.PayCalculator.GetType() == typeof(HourlyPayCalculator))
                {
                }
                else
                {
                    // TODO... for CommissionPayCalculator
                }

                cmd.ExecuteNonQuery();
            }
            
            

            conn.Close();

            // salvo la lista di Employee su una tabella del database.

            // recupero dal database la lista.

            // verifico che la nuova lista ha gli stessi valori
            // della lista di partenza.
        }

        private List<Employee> createEmployees()
        {
            var fixedCalc = new FixedPayCalculator();
            fixedCalc.MonthlySalary = 1500;

            var hourlyCalc = new HourlyPayCalculator();
            hourlyCalc.HourlySalary = 20;
            hourlyCalc.AddWorkedHours(new DateTime(2018, 1, 15), 8);
            hourlyCalc.AddWorkedHours(new DateTime(2018, 1, 16), 9);

            var commissionCalc = new CommissionPayCalculator();
            commissionCalc.CommissionPercentage = (decimal)0.02;
            commissionCalc.AddCommission(new DateTime(2018, 1, 20), 10000);
            commissionCalc.AddCommission(new DateTime(2018, 1, 29), 20000);

            var list = new List<Employee>
            {
                new Employee { Name = "Mario Rossi", PayCalculator = fixedCalc },
                new Employee { Name = "Tonio Cartonio", PayCalculator = hourlyCalc },
                new Employee { Name = "Gigi Pirola", PayCalculator = commissionCalc },
            };

            return list;
        }

        private void InsertFixedPayEmployee(Employee e, IDbConnection conn)
        {
            var fixedCalc = (FixedPayCalculator)e.PayCalculator;

            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "INSERT INTO Employees " +
                "(Name,PayCalculatorType,TotalPay,MonthlySalary)" +
                "VALUES" +
                "(@Name, @PayCalculatorType,@TotalPay,@MonthlySalary)";

            cmd.Parameters.Add(new SqlParameter("Name", e.Name));
            cmd.Parameters.Add(new SqlParameter("PayCalculatorType", e.PayCalculator.GetType().Name));
            cmd.Parameters.Add(new SqlParameter("TotalPay", e.TotalPay));
            cmd.Parameters.Add(new SqlParameter("MonthlySalary", fixedCalc.MonthlySalary));

            cmd.ExecuteNonQuery();
        }

        private void InsertHourlyPayEmployee(Employee e, IDbConnection conn)
        {
            var hourlyCalc = (HourlyPayCalculator)e.PayCalculator;

            var employeeCmd = conn.CreateCommand();
            employeeCmd.CommandType = CommandType.Text;
            employeeCmd.CommandText =
                "INSERT INTO Employees " +
                "(Name,PayCalculatorType,TotalPay,HourlySalary) OUTPUT INSERTED.ID" +
                "VALUES" +
                "(@Name, @PayCalculatorType,@TotalPay,@HourlySalary);";

            employeeCmd.Parameters.Add(new SqlParameter("Name", e.Name));
            employeeCmd.Parameters.Add(new SqlParameter("PayCalculatorType", e.PayCalculator.GetType().Name));
            employeeCmd.Parameters.Add(new SqlParameter("TotalPay", e.TotalPay));
            employeeCmd.Parameters.Add(new SqlParameter("HourlySalary", hourlyCalc.HourlySalary));

            var employeeId = (int)employeeCmd.ExecuteScalar();

            foreach(var s in hourlyCalc.Hours)
            {
                var schedulationCmd = conn.CreateCommand();
                schedulationCmd.CommandType = CommandType.Text;
                schedulationCmd.CommandText =
                    "INSERT INTO Schedulations " +
                    "(EmployeeId,Date,WorkedHours)" +
                    "VALUES" +
                    "(@EmployeeId, @Date,@WorkedHours);";

                schedulationCmd.Parameters.Add(new SqlParameter("EmployeeId", employeeId));
                schedulationCmd.Parameters.Add(new SqlParameter("Date", s.Key));
                schedulationCmd.Parameters.Add(new SqlParameter("WorkedHours", s.Value));

                schedulationCmd.ExecuteNonQuery();
            }
        }
    }
}
