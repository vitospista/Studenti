using CorsoEnaip2018_ProjectManagement.DataAccess;
using CorsoEnaip2018_ProjectManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ProjectManagement.Controllers
{
    public class ProjectController : Controller
    {
        private IRepository<Project> _repository;

        public ProjectController(IRepository<Project> repository)
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
            var model = _repository.Find(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Project model)
        {
            var result = _repository.Update(model);

            if (!result)
                return NotFound();

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
        public IActionResult Delete(Project model)
        {
            var result = _repository.Delete(model);

            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
