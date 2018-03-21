using CorsoEnaip2018_SuperHeroes.DataAccess;
using CorsoEnaip2018_SuperHeroes.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CorsoEnaip2018_SuperHeroes.Controllers
{
    public class VillainController : Controller
    {
        private IRepository<Villain> _repository;
        private IRepository<SuperHero> _superHeroRepository;

        // Dependency Injection
        // Inietto un'istanza di IRepository<SuperHero>
        // da fuori.
        public VillainController(
            IRepository<Villain> repository,
            IRepository<SuperHero> superHeroRepository)
        {
            _repository = repository;
            _superHeroRepository = superHeroRepository;
        }

        public IActionResult Index()
        {
            var models = _repository.FindAll();

            return View(models);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Villain model;

            if (id == 0)
            {
                model = new Villain();
            }
            else
            {
                model = _repository.Find(id);

                if (model == null)
                    return NotFound();
            }

            ViewData["nemeses"] = _superHeroRepository.FindAll();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Villain model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var message = model.Id == 0
                ? $"Aggiunto cattivo '{model.Name}'"
                : $"Modificato cattivo '{model.Name}";

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

            TempData["Message"] = message;

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
        public IActionResult Delete(Villain model)
        {
            var success = _repository.Delete(model);

            if (!success)
                return NotFound();

            TempData["message"] = $"Rimosso cattivo '{model.Name}'";

            return RedirectToAction(nameof(Index));
        }
    }
}
