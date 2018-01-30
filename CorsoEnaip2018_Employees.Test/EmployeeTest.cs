using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorsoEnaip2018_Employees;
using System.Collections.Generic;

namespace CorsoEnaip2018_Employees.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void new_Employee_add_0_to_salary()
        {
            var e = new Employee();
            e.AddSalary(2018, 1);
            Assert.AreEqual(0, e.TotalPay);
        }

        [TestMethod]
        public void Employee_AddSalary_cumulates_salaries()
        {
            var c = new FixedPayCalculator();
            c.MonthlySalary = 1000;

            var e = new Employee();
            e.PayCalculator = c;

            Assert.AreEqual(0, e.TotalPay);

            e.AddSalary(2018, 1);
            Assert.AreEqual(1000, e.TotalPay);

            e.AddSalary(2018, 2);
            e.AddSalary(2018, 3);
            Assert.AreEqual(3000, e.TotalPay);
        }

        [TestMethod]
        public void Give_Pay_to_a_list_of_employees_works()
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

            var noFamilyCalc = new NoFamilyBonusCalculator();
            var bigFamilyCalc = new BigFamilyBonusCalculator();

            var list = new List<Employee>
            {
                new Employee { PayCalculator = fixedCalc, BonusCalculator = noFamilyCalc },
                new Employee { PayCalculator = hourlyCalc, BonusCalculator = noFamilyCalc },
                new Employee { PayCalculator = commissionCalc, BonusCalculator = bigFamilyCalc },
            };

            foreach(var e in list)
                e.AddSalary(2018, 1);

            list[1].PayCalculator = fixedCalc;
            list[2].PayCalculator = fixedCalc;

            foreach (var e in list)
                e.AddSalary(2018, 2);
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
