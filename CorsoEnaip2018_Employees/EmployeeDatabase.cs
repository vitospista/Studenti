﻿using System;
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

                //saveBonusCalculator(e);

                //saveMalusCalculator(e);
            }

            _connection.Close();
        }

        //public void Save(Employee e, PayCalculator payCalculator)
        //{
            
        //}

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


        private void saveBonusCalculator(Employee e, SqlConnection conn)
        {
            throw new NotImplementedException();
        }

        private void saveMalusCalculator(Employee e, SqlConnection conn)
        {
            throw new NotImplementedException();
        }

        private int saveEmployee(Employee e)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                " INSERT INTO Employees" +
                " (Name,TotalPay) OUTPUT INSERTED.ID" +
                " VALUES" +
                " (@Name,@TotalPay)";

            cmd.Parameters.Add(new SqlParameter("Name", e.Name));
            cmd.Parameters.Add(new SqlParameter("TotalPay", e.TotalPay));

            int id = (int)cmd.ExecuteScalar();

            return id;
        }








        public List<Employee> FindAll()
        {
            throw new NotImplementedException();
        }

    }
}