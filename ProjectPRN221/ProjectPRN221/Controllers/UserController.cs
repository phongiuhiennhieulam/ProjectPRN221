using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectPRN221.Models;
using System.Linq;

namespace ProjectPRN221.Controllers
{
    public class UserController : Controller
    {
        Project_SU23Context shopDB = new Project_SU23Context();
        public IActionResult Account()
        {
            var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
            ViewBag.account = acc;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        //Chờ xác nhận đơn
        public IActionResult ToPay()
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
        
        //Đăng giao
        public IActionResult ToReceive()
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

        //Đã giao hàng
        public IActionResult Completed()
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

        //Hủy đơn hàng
        public IActionResult Cancelled() 
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

        public IActionResult CancelOrder(int Id)
        {
            return View();
        }

        public IActionResult ReOrder()
        {
            return View();
        }

        public IActionResult ContactTo()
        {
            return View();
        }

    }
}
