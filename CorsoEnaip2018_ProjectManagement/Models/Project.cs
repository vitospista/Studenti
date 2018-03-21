using System;

namespace CorsoEnaip2018_ProjectManagement.Models
{
// Invece di SqlReader e SqlCommand, usare EntityFramework
// Per l'Index di Project, creare un ViewModel solo coi dati necessari
// A scelta, Customer o Manager devono essere entità esterne,
// collegate da una relazione uno-a-molti con la classe Project.
// Sulla View di Edit, usare un 'select' per selezionare Customer/Manager



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
