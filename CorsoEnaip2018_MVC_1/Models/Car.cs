using System;

namespace CorsoEnaip2018_MVC_1.Models
{
    public class Car
    {
        public Car() { }

        public Car(
            int id, string brand, string name,
            int day, int month, int year, decimal price)
        {
            Id = id;
            Brand = brand;
            Name = name;
            Created = new DateTime(year, month, day);
            Price = price;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public decimal Price { get; set; }
    }

    // POCO --> Plain Old C# Objects
    // POJO --> Plain Old Java Objects
}
