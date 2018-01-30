using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorsoEnaip2018_Employees.Test
{
    [TestClass]
    public class MalusCalculatorTest
    {
        [TestMethod]
        public void NoLegalRefund_does_not_subtract_from_salary()
        {
            var e = new Employee();
            e.PayCalculator = new FixedPayCalculator { MonthlySalary = 1000 };

            e.AddSalary(2018, 1);

            Assert.AreEqual(1000, e.TotalPay);
        }

        [TestMethod]
        public void LegalRefund_subtracts_the_fifth_from_salary()
        {
            var e = new Employee();
            e.PayCalculator = new FixedPayCalculator { MonthlySalary = 1000 };
            e.MalusCalculator = new LegalRefundCalculator();

            e.AddSalary(2018, 1);

            Assert.AreEqual(800, e.TotalPay);
        }
    }
}
