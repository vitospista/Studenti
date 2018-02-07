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
    public class SaveToDatabaseTest
    {
        [TestMethod]
        public void SaveAndGet()
        {
            // creo lista di Employee con Pay/Bonus/Malus diversi.
            var list = createEmployees();

            var db = new EmployeeDatabase(@"Data Source=TRISRV10\SQLEXPRESS;Initial Catalog=CorsoEuris_Kraus;Integrated Security=True");

            db.Save(list);

            var saved = db.FindAll();

            // fare un po' di assert per verificare che
            // i valori tirati su dal database siano proprio quelli della 
            // lista originale
            Assert.AreEqual("Mario Rossi", saved[0].Name);

            // TODO: assert...
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
                new Employee
                {
                    Name = "Mario Rossi",
                    PayCalculator = fixedCalc,
                    BonusCalculator = new BigFamilyBonusCalculator()
                },
                new Employee
                {
                    Name = "Tonio Cartonio",
                    PayCalculator = hourlyCalc,
                    BonusCalculator = new LittleFamilyBonusCalculator()
                },
                new Employee
                {
                    Name = "Gigi Pirola",
                    PayCalculator = commissionCalc,
                    BonusCalculator = new NoFamilyBonusCalculator()
                },
            };

            return list;
        }
    }
}
