using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectPRN221.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
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
			if (HttpContext.Session.GetString("seft") != null)
			{
				ViewBag.seft = HttpContext.Session.GetString("seft");
				HttpContext.Session.Remove("seft");
			}
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
					}
					else
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
				count = 0;
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

		public IActionResult Login()
		{
			ViewBag.acc = null;
			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public IActionResult Login(string email, string password)
		{
			if (email == null && password == null)
			{
				ViewBag.lo = "Wrong email or passoword";
				return View("Login");
			}
			var account = shopDB.Accounts.FirstOrDefault(x => x.AccountEmail == email && x.AccountPassword == password);
			if (account == null)
			{
				ViewBag.lo = "Wrong email or passoword";
				return View("Login");
			}

			if (account != null && account.AccountStatus == false)
			{
				ViewBag.lo = "Account has been ban. You need to contact with Admin to reset you account!!!";
				return View("Login");
			}

			if (account != null)
			{
				if (account.AccountRoleId == 1)
				{
					HttpContext.Session.SetString("account", JsonConvert.SerializeObject(account));
					return RedirectToAction("ProductHome", "Product");
				}
				if (account.AccountRoleId == 2)
				{
					HttpContext.Session.SetString("account", JsonConvert.SerializeObject(account));
					return RedirectToAction("Index", "Home");
				}
			}
			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public IActionResult Register(string fullname, string email, string address, string username, string password, string phone)
		{
			if (fullname == null || email == null || username == null || password == null || phone == null)
			{
				ViewBag.re = "Fill all field";
				return View("Login");
			}

			Account account = new Account
			{
				AccountUsername = fullname,
				AccountEmail = email,
				AccountAddress = address,
				AccountPhone = phone,
				AccountPassword = password,
				AccountName = username,
			};
			shopDB.Accounts.Add(account);
			shopDB.SaveChanges();
			HttpContext.Session.SetString("account", JsonConvert.SerializeObject(account));
			return View();
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Remove("account");
			return RedirectToAction("ProductHome", "Product");
		}
	}
}
