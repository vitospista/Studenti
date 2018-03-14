using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorsoEnaip2018_SuperHeroes.Models;
using CorsoEnaip2018_SuperHeroes.Infrastructure;
using CorsoEnaip2018_SuperHeroes.DataAccess;

namespace CorsoEnaip2018_SuperHeroes.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<SuperHero> _repository;

        // Dependency Injection
        // Inietto un'istanza di IRepository<SuperHero>
        // da fuori.
        public HomeController(IRepository<SuperHero> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var models = _repository.FindAll();

            return View(models);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            SuperHero model;

            if (id == 0)
            {
                model = new SuperHero { Birth = DateTime.Now };
            }
            else
            {
                model = _repository.Find(id);

                if (model == null)
                    return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SuperHero model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id == 0)
            {
                _repository.Insert(model);
            }
            else
            {
                var result = _repository.Update(model);
                if (!result)
                    return NotFound();
            }

            TempData["Message"] =
                $"Aggiunto supereroe '{model.Name}'";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _repository.Find(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(SuperHero model)
        {
            var success = _repository.Delete(model);

            if (!success)
                return NotFound();

            TempData["message"] = $"Rimosso supereroe {model.Name}";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
