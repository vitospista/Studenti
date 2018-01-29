using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Employees
{
    /* devo gestire diversi tipi di impiegati:
    * 1) dipendenti diretti: paga fissa mensile
    * 2) dipendenti a ore: tot paga all'ora;
    *     50% in più per le ore di straordinario (+ di 8 ore).
    * 3) dipendenti per commessa: pagati solo sulle commesse che vendono
    *     (prendono una percentuale).
    * 
    * Ogni ultimo del mese il sistema Payroll entra in gioco,
    * itera sulla lista di Employee, per ognuno calcola la paga,
    * e gliela aggiunge al conto.
    * 
    * Ogni Employee ha un metodo CalculatePay, e una proprietà TotalPay.
    */

    public abstract class Employee
    {
        public decimal TotalPay { get; private set; }

        public void AddSalary(decimal salary)
        {
            TotalPay += salary;
        }

        public abstract decimal CalculatePay(int year, int month);
    }

    public class FixedSalaryEmployee : Employee
    {
        public decimal MonthlySalary { get; set; }

        public override decimal CalculatePay(int year, int month)
        {
            return MonthlySalary;
        }
    }

    public class HourlyEmployee : Employee
    {
        private Dictionary<DateTime, int> _hours;

        public HourlyEmployee()
        {
            _hours = new Dictionary<DateTime, int>();
        }

        public void AddWorkedHours(DateTime day, int hours)
        {
            if (_hours.ContainsKey(day))
            {
                _hours[day] += hours;
                // è esattamente equivalente a:
                //_hours[day] = _hours[day] + hours;
            }
            else
            {
                _hours.Add(day, hours);
            }
        }

        public override decimal CalculatePay(int year, int month)
        {
            decimal totalMonthlySalary = 0;

            var filteredHours = _hours
                .Where(x => x.Key.Year == year && x.Key.Month == month);

            foreach (var h in filteredHours)
                totalMonthlySalary += amoutForHours(h.Value);

            return totalMonthlySalary;
        }

        private decimal amoutForHours(int h)
        {
            var extraordinaries = h - 8;

            if (extraordinaries > 0)
            {
                return 8 * HourlySalary + extraordinaries * HourlySalary * (decimal)1.5;
            }
            else
            {
                return h * HourlySalary;
            }
        }

        public decimal HourlySalary { get; set; }
    }

    public class CommissionEmployee : Employee
    {
        private Dictionary<DateTime, decimal> _commissions;

        public CommissionEmployee()
        {
            _commissions = new Dictionary<DateTime, decimal>();
        }

        public decimal CommissionPercentage { get; set; }

        public override decimal CalculatePay(int year, int month)
        {
            return _commissions
                .Where(x => x.Key.Year == year && x.Key.Month == month)
                .Sum(x => x.Value) * CommissionPercentage;
        }

        public void AddCommission(DateTime day, decimal amount)
        {
            if (_commissions.ContainsKey(day))
            {
                _commissions[day] += amount;
            }
            else
            {
                _commissions.Add(day, amount);
            }
        }
    }
}
