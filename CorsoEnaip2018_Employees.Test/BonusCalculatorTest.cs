using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorsoEnaip2018_Employees.Test
{
    [TestClass]
    public class BonusCalculatorTest
    {
        [TestMethod]
        public void NoBonus_does_not_add_to_salary()
        {
            var e = new Employee();
            e.PayCalculator = new FixedPayCalculator { MonthlySalary = 1000 };

            e.AddSalary(2018, 1);

            Assert.AreEqual(1000, e.TotalPay);
        }

        [TestMethod]
        public void LittleFamilyBonus_adds_to_salary()
        {
            var e = new Employee();
            e.PayCalculator = new FixedPayCalculator { MonthlySalary = 1000 };
            e.BonusCalculator = new LittleFamilyBonusCalculator();

            e.AddSalary(2018, 1);

            Assert.AreEqual(1200, e.TotalPay);
        }
    }
}
