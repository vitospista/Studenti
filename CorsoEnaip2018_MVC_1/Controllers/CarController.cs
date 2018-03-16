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

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = Models.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Car model)
        {
            // questo è più semplice da scrivere
            // ma meno performante,
            // inoltre non toglie un solo elemento, ma TUTTI gli elementi
            // che rispettano la condizione.
            // Models.RemoveAll(x => x.Id == model.Id);

            // questo compie due iterazioni,
            // una per trovare l'oggetto,
            // e l'altra per rimuoverlo
            //var toDelete = Models.FirstOrDefault(x => x.Id == model.Id);
            //Models.Remove(toDelete);

            // è il più performante:
            // esegue una singola iterazione.
            var index = Models.FindIndex(x => x.Id == model.Id);

            if (index == -1)
                return NotFound();

            Models.RemoveAt(index);

            return RedirectToAction(nameof(Index));
        }
    }
}
