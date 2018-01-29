using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorsoEnaip2018_Employees;

namespace CorsoEnaip2018_Employees.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void Employee_AddSalary_cumulates_salaries()
        {
            var e = new FixedSalaryEmployee();

            Assert.AreEqual(0, e.TotalPay);

            e.AddSalary(1000);
            Assert.AreEqual(1000, e.TotalPay);

            e.AddSalary(2000);
            e.AddSalary(2000);
            Assert.AreEqual(5000, e.TotalPay);
        }

        [TestMethod]
        public void FixedSalaryEmployee_CalculatePay_is_correct()
        {
            var e = new FixedSalaryEmployee();

            e.MonthlySalary = 1500;

            var pay = e.CalculatePay(2018, 1);

            Assert.AreEqual(1500, pay);
        }

        [TestMethod]
        public void HourlyEmployee_CalculatePay_is_correct()
        {
            var e = new HourlyEmployee();
            e.HourlySalary = 20;
            Assert.AreEqual(0, e.CalculatePay(2018, 1));

            e.AddWorkedHours(new DateTime(2018, 1, 29), 4);
            Assert.AreEqual(80, e.CalculatePay(2018, 1));

            e.AddWorkedHours(new DateTime(2018, 1, 30), 10);
            Assert.AreEqual(300, e.CalculatePay(2018, 1), "only January hours");

            e.AddWorkedHours(new DateTime(2017, 12, 23), 6);
            Assert.AreEqual(300, e.CalculatePay(2018, 1), "added non-January hours");

            e.AddWorkedHours(new DateTime(2018, 1, 29), 3);
            Assert.AreEqual(360, e.CalculatePay(2018, 1));
            /*
             * 20 € / ora
             * 
             * 29 Jan
             * 4 ore => 4 * 20 = 80
             * 
             * 30 Jan
             * 10 ore => 8 * 20 + 2 * 30 = 160 + 60 = 220
             * 
             * Total Jan = 300
             * 
             */

        }

        [TestMethod]
        public void CommissionEmployee_CalculatePay_is_correct()
        {
            var e = new CommissionEmployee();
            e.CommissionPercentage = (decimal)0.02;
            Assert.AreEqual(0, e.CalculatePay(2018, 1));

            e.AddCommission(new DateTime(2018, 1, 2), 40000); // 800
            e.AddCommission(new DateTime(2018, 1, 15), 5000); // 100
            Assert.AreEqual(900, e.CalculatePay(2018, 1));

            e.AddCommission(new DateTime(2018, 2, 15), 10000);
            Assert.AreEqual(900, e.CalculatePay(2018, 1));

            e.AddCommission(new DateTime(2018, 1, 15), 10000); // 200
            Assert.AreEqual(1100, e.CalculatePay(2018, 1));
        }

        // TODO: approfondire Equals
        //[TestMethod]
        //public void CheckC()
        //{
        //    var c1 = new C { Id = 1 };
        //    var c2 = new C { Id = 1 };

        //    Assert.AreEqual(c1, c2);
        //    Assert.IsTrue((c1 == null && c2 == null) || c1.Equals(c2));
        //    Assert.IsTrue(c1 == c2);

        //}

        //class C
        //{
        //    public int Id { get; set; }

        //    public override bool Equals(object obj)
        //    {
        //        var other = obj as C;

        //        if (other == null)
        //            return false;

        //        return Id == other.Id;
        //    }

        //    public override int GetHashCode()
        //    {
        //        return Id;
        //    }
        //}
    }
}
