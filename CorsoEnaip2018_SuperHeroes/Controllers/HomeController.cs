using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorsoEnaip2018_SuperHeroes.Models;
using CorsoEnaip2018_SuperHeroes.Infrastructure;

namespace CorsoEnaip2018_SuperHeroes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData[Constants.TITLE_KEY] = "SuperHeroes da ViewData";
            ViewBag.BagTitle = "SuperHeroes da ViewBag";

            var td = TempData;
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new SuperHero();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SuperHero model)
        {
            // ...

            TempData["Message"] =
                $"Aggiunto supereroe '{model.Name}'";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
