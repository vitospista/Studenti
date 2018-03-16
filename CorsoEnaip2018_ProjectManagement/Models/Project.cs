using System;

namespace CorsoEnaip2018_ProjectManagement.Models
{
    public class Project
    {
        public Project() { }

        public Project(
            int id,
            string name,
            string customer,
            string manager,
            DateTime startDate,
            DateTime endDate,
            DateTime deliveryDate,
            decimal price,
            decimal cost)
        {
            Id = id;
            Name = name;
            Customer = customer;
            Manager = manager;
            StartDate = startDate;
            EndDate = endDate;
            DeliveryDate = deliveryDate;
            Price = price;
            Cost = cost;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Customer { get; set; }
        public string Manager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
