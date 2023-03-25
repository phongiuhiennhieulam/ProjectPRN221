using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectPRN221.Models;
using System.Linq;

namespace ProjectPRN221.Controllers
{
    public class UserController : Controller
    {
        bool isLogin = false;

        Project_SU23Context shopDB = new Project_SU23Context();
        public IActionResult Account()
        {
           
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("Product", "Admin");
            } else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 1)
                {
                    ViewBag.account = acc;
                    return View();
                }
                return RedirectToAction("", "");
            }
            
        }

        public IActionResult Index()
        {
            return View();
        }

        //Chờ xác nhận đơn
        public IActionResult ToPay()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            } else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 1)
                {
                    var status = shopDB.OrderStatuses.FirstOrDefault(x => x.OrderStatusStatus == "Chờ xác nhận");
                    var lstToPay = shopDB.Orders.Where(x => x.OrderStatusId == status.OrderStatusId).ToList();
                    var lstOrderDetail = shopDB.OrderDetails.ToList();
                    var lstProduct = shopDB.Products.ToList();

                    ViewBag.lstProduct = lstProduct;
                    ViewBag.lstToPay = lstToPay;
                    ViewBag.lstOrderDetail = lstOrderDetail;
                    ViewBag.status = status;
                    ViewBag.cate = "ToPay";
                    return View();
                }

                return RedirectToAction("", "");
            }
        }
        
        //Đăng giao
        public IActionResult ToReceive()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 1)
                {
                    var status = shopDB.OrderStatuses.FirstOrDefault(x => x.OrderStatusStatus == "Đang giao");
                    var lstToReceive = shopDB.Orders.Where(x => x.OrderStatusId == status.OrderStatusId).ToList();
                    var lstOrderDetail = shopDB.OrderDetails.ToList();
                    var lstProduct = shopDB.Products.ToList();

                    ViewBag.lstProduct = lstProduct;
                    ViewBag.lstToReceive = lstToReceive;
                    ViewBag.lstOrderDetail = lstOrderDetail;
                    ViewBag.cate = "ToReceive";

                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        //Đã giao hàng
        public IActionResult Completed()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 1)
                {
                    var status = shopDB.OrderStatuses.FirstOrDefault(x => x.OrderStatusStatus == "Đã giao hàng");
                    var lstCompleted = shopDB.Orders.Where(x => x.OrderStatusId == status.OrderStatusId).ToList();
                    var lstOrderDetail = shopDB.OrderDetails.ToList();
                    var lstProduct = shopDB.Products.ToList();

                    ViewBag.lstProduct = lstProduct;
                    ViewBag.lstCompleted = lstCompleted;
                    ViewBag.lstOrderDetail = lstOrderDetail;
                    ViewBag.cate = "Completed";
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        //Hủy đơn hàng
        public IActionResult Cancelled() 
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 1)
                {
                    var status = shopDB.OrderStatuses.FirstOrDefault(x => x.OrderStatusStatus == "Hủy đơn hàng");
                    var lstCancelled = shopDB.Orders.Where(x => x.OrderStatusId == status.OrderStatusId).ToList();
                    var lstOrderDetail = shopDB.OrderDetails.ToList();
                    var lstProduct = shopDB.Products.ToList();

                    ViewBag.lstProduct = lstProduct;
                    ViewBag.lstCancelled = lstCancelled;
                    ViewBag.lstOrderDetail = lstOrderDetail;
                    ViewBag.cate = "Cancelled";
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        public IActionResult CancelOrder(int Id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 1)
                {
                    var order = shopDB.Orders.FirstOrDefault(x => x.OrderId == Id);
                    order.OrderStatusId = 6;
                    shopDB.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    shopDB.SaveChanges();
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        public IActionResult SeftAccount()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 1)
                {
                    var a = shopDB.Accounts.FirstOrDefault(x => x.AccountId == 1);
                    ViewBag.acc = a;
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult SeftAccount(string img, string AccountImage, Account account)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 1)
                {
                    if (!ModelState.IsValid)
                    {
                        ViewBag.acc = acc;
                        return View("SeftAccount");
                    }

                    if (AccountImage == null)
                    {
                        account.AccountImage = img;
                    }

                    account.AccountRoleId = 1;
                    shopDB.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    shopDB.SaveChanges();
                    return RedirectToAction("ToPay", "User");
                }
                return RedirectToAction("", "");
            }
        }
        public IActionResult ReOrder(int Id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 1)
                {
                    Cart cart = new Cart
                    {

                    };

                    CartDetail cartDetail = new CartDetail
                    {

                    };
                    return RedirectToAction("", "");
                }
                return RedirectToAction("", "");
            }
        }

        public IActionResult ContactTo()
        {
            return View();
        }

    }
}
