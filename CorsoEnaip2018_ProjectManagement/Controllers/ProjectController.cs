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
        private static readonly List<Project> _projects = new List<Project>
        {
            new Project(1, "Manhattan", "Generali SPA", "Mario Rossi", new DateTime(2018, 1, 1), new DateTime(2018, 2, 2), new DateTime(2018, 1, 31), 50000, 30000),
            new Project(2, "Marshall", "Danieli SRL", "Luigi Neri", new DateTime(2017, 6, 6), new DateTime(2017, 12, 31), new DateTime(2017, 12, 15), 100000, 80000),
            new Project(3, "Area 51", "Dottor Evil", "Anna Gialli", new DateTime(2018, 1, 1), new DateTime(2018, 4, 10), new DateTime(2018, 4, 10), 50000, 30000),
        };

        public IActionResult Index()
        {
            return View(_projects);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _projects.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Project model)
        {
            var index = _projects.FindIndex(x => x.Id == model.Id);

            if (index == -1)
                return NotFound();

            _projects[index] = model;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _projects.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Project model)
        {
            var index = _projects.FindIndex(x => x.Id == model.Id);

            if (index == -1)
                return NotFound();

            _projects.RemoveAt(index);

            return RedirectToAction(nameof(Index));
        }
    }
}
