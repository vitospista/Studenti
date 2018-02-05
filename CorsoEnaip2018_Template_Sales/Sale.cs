using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Template_Sales
{
    class Sale
    {
        public Sale() { }

        public Sale(string product, string employee, string shop, DateTime date, decimal amount)
        {
            ProductName = product;
            EmployeeName = employee;
            ShopName = shop;
            Date = date;
            Amount = amount;
        }

        public string ProductName { get; set; }
        public string EmployeeName { get; set; }
        public string ShopName { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
