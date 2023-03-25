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
        Project_SU23Context shopDB = new Project_SU23Context();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.slProduct = shopDB.Products.ToList().Count;
            ViewBag.slOrder = shopDB.Orders.ToList().Count;
            ViewBag.slCus = shopDB.Accounts.Where(x => x.AccountRoleId == 1).ToList().Count;
            double profit = 0;
            foreach (var item in shopDB.Orders.ToList())
            {
                profit += item.OrderTotalMoney;
            }
            ViewBag.profit = profit;
            ViewBag.cate = "Dashboard";
            return View();
        }
    }
}
