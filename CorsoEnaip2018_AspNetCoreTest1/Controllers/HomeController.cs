using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorsoEnaip2018_AspNetCoreTest1.Models;
using CorsoEnaip2018_AspNetCoreTest1.DataAccess;

namespace CorsoEnaip2018_AspNetCoreTest1.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var models = _repository.GetList();

            return View(models);
        }
    }
}
