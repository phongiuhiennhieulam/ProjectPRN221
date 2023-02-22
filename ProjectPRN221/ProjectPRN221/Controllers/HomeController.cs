using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectPRN221.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPRN221.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.cate = "Dashboard";
            return View();
        }
    }
}
