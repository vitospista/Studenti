using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_MVC_1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Ciao bello!";
        }
    }
}
