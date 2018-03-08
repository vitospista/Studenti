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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            #region soluzione meno efficiente
            // questo funziona ma è poco efficiente
            // (sia Any che First scorrono tutta la lista
            //     fino a trovare un match)
            //if (Models.Any(x => x.Id == id))
            //{
            //    var model = Models.First(x => x.Id == id);

            //    return View(model);
            //}
            //else
            //{
            //    return NotFound();
            //}
            #endregion

            var model = Models.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Car model)
        {
            #region soluzione meno efficiente
            // questo funziona ma è poco efficiente
            // (sia Any che First scorrono tutta la lista
            //     fino a trovare un match)
            //var old = Models.FirstOrDefault(x => x.Id == model.Id);

            //var index = Models.IndexOf(old);

            //Models[index] = model;
            #endregion

            var index = Models.FindIndex(x => x.Id == model.Id);

            if (index == -1)
                return NotFound();

            Models[index] = model;

            return View("Index", Models);
        }
    }
}
