using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Employees.Test
{
    [TestClass]
    public class PayCalculatorTest
    {
        [TestMethod]
        public void Fixed_CalculatePay()
        {
            var c = new FixedPayCalculator();

            c.MonthlySalary = 1500;

            var pay = c.CalculatePay(2018, 1);

            Assert.AreEqual(1500, pay);
        }

        [TestMethod]
        public void Hourly_CalculatePay()
        {
            var c = new HourlyPayCalculator();
            c.HourlySalary = 20;
            Assert.AreEqual(0, c.CalculatePay(2018, 1));

            c.AddWorkedHours(new DateTime(2018, 1, 29), 4);
            Assert.AreEqual(80, c.CalculatePay(2018, 1));

            c.AddWorkedHours(new DateTime(2018, 1, 30), 10);
            Assert.AreEqual(300, c.CalculatePay(2018, 1), "only January hours");

            c.AddWorkedHours(new DateTime(2017, 12, 23), 6);
            Assert.AreEqual(300, c.CalculatePay(2018, 1), "added non-January hours");

            c.AddWorkedHours(new DateTime(2018, 1, 29), 3);
            Assert.AreEqual(360, c.CalculatePay(2018, 1));
        }

        [TestMethod]
        public void Commission_CalculatePay()
        {
            var c = new CommissionPayCalculator();
            c.CommissionPercentage = (decimal)0.02;
            Assert.AreEqual(0, c.CalculatePay(2018, 1));

            c.AddCommission(new DateTime(2018, 1, 2), 40000);
            c.AddCommission(new DateTime(2018, 1, 15), 5000);
            Assert.AreEqual(900, c.CalculatePay(2018, 1));

            c.AddCommission(new DateTime(2018, 2, 15), 10000);
            Assert.AreEqual(900, c.CalculatePay(2018, 1));

            c.AddCommission(new DateTime(2018, 1, 15), 10000);
            Assert.AreEqual(1100, c.CalculatePay(2018, 1));
        }
    }
}
