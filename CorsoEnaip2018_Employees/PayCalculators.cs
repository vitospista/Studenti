using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Employees
{
    public abstract class PayCalculator
    {
        public abstract decimal CalculatePay(int year, int month);

        public abstract void AcceptSaver(ISaver saver, Employee e);
    }

    public class FixedPayCalculator : PayCalculator
    {
        public decimal MonthlySalary { get; set; }

        public override void AcceptSaver(ISaver saver, Employee e)
        {
            saver.Save(e, this);
        }

        public override decimal CalculatePay(int year, int month)
        {
            return MonthlySalary;
        }
    }

    public class HourlyPayCalculator : PayCalculator
    {
        public IReadOnlyDictionary<DateTime, int> Hours
        {
            get { return _hours; }
        }
        private Dictionary<DateTime, int> _hours;

        public HourlyPayCalculator()
        {
            _hours = new Dictionary<DateTime, int>();
        }

        public override void AcceptSaver(ISaver saver, Employee e)
        {
            saver.Save(e, this);
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

        public decimal HourlySalary { get; set; }
    }

    public class CommissionPayCalculator : PayCalculator
    {
        public IReadOnlyDictionary<DateTime, decimal> Commissions
        {
            get { return _commissions; }
        }

        private readonly Dictionary<DateTime, decimal> _commissions;

        public CommissionPayCalculator()
        {
            _commissions = new Dictionary<DateTime, decimal>();
        }

        public decimal CommissionPercentage { get; set; }

        public override void AcceptSaver(ISaver saver, Employee e)
        {
            saver.Save(e, this);
        }

        public override decimal CalculatePay(int year, int month)
        {
            return _commissions
                .Where(x => x.Key.Year == year && x.Key.Month == month)
                .Sum(x => x.Value) * CommissionPercentage;
        }

        public void AddCommission(DateTime day, decimal amount)
        {
            if (_commissions.ContainsKey(day))
                _commissions[day] += amount;
            else
                _commissions.Add(day, amount);
        }
    }

    public class NullPayCalculator : PayCalculator
    {
        static NullPayCalculator()
        {
            Instance = new NullPayCalculator();
        }

        public static NullPayCalculator Instance { get; }

        private NullPayCalculator()
        { }

        public override void AcceptSaver(ISaver saver, Employee e)
        {
            saver.Save(e, this);
        }

        public override decimal CalculatePay(int year, int month)
        {
            return 0;
        }
    }
}
