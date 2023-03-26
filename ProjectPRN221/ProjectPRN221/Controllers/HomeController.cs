using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
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
        public List<Earning> lstEarning = new List<Earning>();
        public List<Product> lstProduct = new List<Product>();
        public List<Order> lstOrderTody = new List<Order>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public class Earning
        {
            public int Month { get; set; }
            public int TotalOrder { get; set; }
            public double Profit { get; set; }
            public Earning() { }
            public Earning(int month, int totalOrder, double profit)
            {
                Month = month;
                TotalOrder = totalOrder;
                Profit = profit;
            }
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

            foreach (var item in shopDB.Orders.ToList())
            {
                string a = string.Format("{0:dd/MM/yyyy}", item.OrderDate);
                string now = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                if (a == now)
                {
                    lstOrderTody.Add(item);
                }
            }
            ViewBag.orderToday = lstOrderTody;

            var lst = shopDB.Products.ToList();
            foreach (var item in lst)
            {
                if (item.ProductQuantity == 0)
                {
                    lstProduct.Add(item);
                }
            }

            ViewBag.lstProduct = lstProduct;
            ViewBag.orderDetail = shopDB.OrderDetails.ToList();
            ViewBag.lst = lst;
            ViewBag.profit = profit;
            ViewBag.cate = "Dashboard";
            return View();
        }

        [HttpGet]
        public IActionResult GetEarning()
        {
            int count = 0;
            double profits = 0;
            for (int i = 1; i <= 12; i++)
            {
                foreach (var item in shopDB.Orders.ToList())
                {
                    if (item.OrderDate == null)
                    {
                        continue;
                    } else
                    {
                        string[] date = convert(string.Format("{0:dd/MM/yyyy}", item.OrderDate));
                        string[] now = convert(string.Format("{0:dd/MM/yyyy}", DateTime.Now));
                        if (int.Parse(date[1]) == i && date[2] == now[2])
                        {
                            count++;
                            profits += item.OrderTotalMoney;
                        }
                    }       
                }
                lstEarning.Add(new Earning(i, count, profits));
                count++;
                profits = 0;
            }
            return Ok(lstEarning);
        }

        public string[] convert(string a)
        {
            //int y = a.IndexOf(' ');
            string[] b = a.Split('/');
            return b;
        }
    }
}
