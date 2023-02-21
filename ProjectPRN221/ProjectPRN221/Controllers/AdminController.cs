using Microsoft.AspNetCore.Mvc;
using ProjectPRN221.Models;
using System.Linq;
using X.PagedList;

namespace ProjectPRN221.Controllers
{
    public class AdminController : Controller
    {
        Project_SU23Context shopDB = new Project_SU23Context();
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Product(string productName, int page=1, int pageSize = 5 )
        {
            var lstProduct = shopDB.Products.ToList().ToPagedList(page, pageSize);
            var lstColor = shopDB.Colors.ToList();
            var lstStatusProduct = shopDB.StatusProducts.ToList();
            if (productName != null)
            {
                lstProduct = lstProduct.Where(x => x.ProductName.Contains(productName)).ToList().ToPagedList(page, pageSize);
            }

            ViewBag.lstProduct = lstProduct;
            ViewBag.lstColor = lstColor;
            ViewBag.lstStatusProduct = lstStatusProduct;
            ViewBag.search = productName;
            ViewBag.cate = "Products";
            return View();
        }

        public IActionResult Blog()
        {
            ViewBag.cate = "Products";
            return View();
        }
    }
}
