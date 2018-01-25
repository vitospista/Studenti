using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Esercizio3
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person
            {
                Age = 55,
                AnnualSalary = 20000
            };

            var b = new Bank();

            var m = b.CreateMortgage(p, 100000);

            Console.WriteLine(m.TotalAmount);
            Console.WriteLine(m.MonthlyRate);
            Console.WriteLine(m.RateCount);
            Console.WriteLine(m.YearCount);

            Console.Read();
        }
    }

    class Bank
    {
        public Mortgage CreateMortgage(Person p, decimal mortgageRequest)
        {
            if (p == null)
                throw new ArgumentNullException("p");

            if (!CanAskMortgage(p))
                throw new InvalidOperationException(
                    "The person has not the minimal qualification for this request");

            var monthlySalary = p.AnnualSalary / 12;
            var monthlyRate = monthlySalary / 5;

            var totalAmount = mortgageRequest * (decimal)1.3;

            var rateCount = (int)Math.Ceiling(totalAmount / monthlyRate);

            var yearCount = (int)Math.Ceiling((decimal)rateCount / 12);

            return new Mortgage
            {
                TotalAmount = totalAmount,
                MonthlyRate = monthlyRate,
                RateCount = rateCount,
                YearCount = yearCount,
            };
        }

        public bool CanAskMortgage(Person p)
        {
            if (p == null)
                throw new ArgumentNullException("p");

            return p.Age < 60 && p.AnnualSalary > 12000;
        }
    }

    class Person
    {
        public int Age { get; set; }
        public decimal AnnualSalary { get; set; }
    }

    class Mortgage
    {
        public decimal TotalAmount { get; set; }
        public decimal MonthlyRate { get; set; }
        public int RateCount { get; set; }
        public int YearCount { get; set; }
    }
}
