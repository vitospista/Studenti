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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        public int CustomerId { get; set; }
        public Company Customer { get; set; }
    }
}
