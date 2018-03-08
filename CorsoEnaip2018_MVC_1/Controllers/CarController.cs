using CorsoEnaip2018_MVC_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_MVC_1.Controllers
{
    public class CarController : Controller
    {
        private readonly static List<Car> Models
            = new List<Car>
            {
                new Car(1, "Mercedes", "SLK400", 5, 2, 2002, 50000),
                new Car(2, "Fiat", "Multipla", 3, 8, 2005, 23000),
                new Car(3, "Lancia", "Delta", 1, 2, 2003, 12000),
            };

        public ViewResult Index()
        {
            return View(Models);
        }

        public ViewResult Edit(int id)
        {
            var model = Models.First(x => x.Id == id);

            return View(model);
        }
    }
}
