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

    public class Employee
    {
        public decimal TotalPay { get; private set; }

        public PayCalculator PayCalculator { get; set; }

        public void AddSalary(int year, int month)
        {
            var salary = PayCalculator.CalculatePay(year, month);

            TotalPay += salary;
        }
    }
}
