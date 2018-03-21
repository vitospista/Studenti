using CorsoEnaip2018_SuperHeroes.DataAccess;
using CorsoEnaip2018_SuperHeroes.Models;
using CorsoEnaip2018_SuperHeroes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CorsoEnaip2018_SuperHeroes.Controllers
{
    public class SuperHeroController : Controller
    {
        private IRepository<SuperHero> _repository;

        // Dependency Injection
        // Inietto un'istanza di IRepository<SuperHero>
        // da fuori.
        public SuperHeroController(IRepository<SuperHero> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var models = _repository
                .FindAll()
                .Select(SuperHeroRow.Map)
                .ToList();

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

    }
}
