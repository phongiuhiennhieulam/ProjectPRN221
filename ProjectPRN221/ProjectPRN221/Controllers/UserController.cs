using Microsoft.AspNetCore.Mvc;

namespace ProjectPRN221.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        //Chờ xác nhận đơn
        public IActionResult ToPay()
        {
            return View();
        }
        
        //Đăng giao
        public IActionResult ToReceive()
        {
            return View();
        }

        //Đã giao hàng
        public IActionResult Completed()
        {
            return View();
        }

        //Hủy đơn hàng
        public IActionResult Cancelled() 
        {
            return View();
        }
    }
}
