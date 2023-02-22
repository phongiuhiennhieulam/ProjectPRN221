using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public IActionResult Product(string search = null, int page=1, int pageSize = 5 )
        {

            var lstProduct = shopDB.Products.ToList().ToPagedList(page, pageSize);
            var lstColor = shopDB.Colors.ToList();
            var lstStatusProduct = shopDB.StatusProducts.ToList();
            if (search != null)
            {
                lstProduct = lstProduct.Where(x => x.ProductName.Contains(search)).ToList().ToPagedList(page, pageSize);
            }

            ViewBag.lstProduct = lstProduct;
            ViewBag.lstColor = lstColor;
            ViewBag.lstStatusProduct = lstStatusProduct;
            ViewBag.search = search;
            ViewBag.cate = "Products";
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var lstColor = shopDB.Colors.ToList();
            var lstStatusProduct = shopDB.StatusProducts.ToList();
            var lstCate = shopDB.Categories.ToList();
            ViewBag.CategoryId = new SelectList(lstCate, "CategoryId", "CategoryName");
            ViewBag.ColorId = new SelectList(lstColor, "ColorId", "ColorName");
            ViewBag.StatusProductId = new SelectList(lstStatusProduct, "StatusProductId", "StatusProductStatus");
            ViewBag.cate = "Products";
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddProduct(Product product) 
        {
            if (!ModelState.IsValid)
            {
                var lstColor = shopDB.Colors.ToList();
                var lstStatusProduct = shopDB.StatusProducts.ToList();
                var lstCate = shopDB.Categories.ToList();
                ViewBag.CategoryId = new SelectList(lstCate, "CategoryId", "CategoryName");
                ViewBag.ColorId = new SelectList(lstColor, "ColorId", "ColorName");
                ViewBag.StatusProductId = new SelectList(lstStatusProduct, "StatusProductId", "StatusProductStatus");
                ViewBag.cate = "Products";
                return View("AddProduct");
            }
            shopDB.Products.Add(product);
            shopDB.SaveChanges();
            return RedirectToAction("Product");
        }

        public IActionResult EditProduct(int Id)
        {
            var product = shopDB.Products.FirstOrDefault(x => x.ProductId == Id);
            ViewBag.product = product;
            return View();
        }

        public IActionResult Blog(string search, int page=1, int pageSize = 5)
        {
            var lstBlog = shopDB.Blogs.ToList().ToPagedList(page, pageSize);
            if (search != null)
            {
                lstBlog = lstBlog.Where(x => x.BlogTitle.ToLower().Contains(search.ToLower())).ToList().ToPagedList(page, pageSize);
            }

            ViewBag.lstBlog = lstBlog;
            ViewBag.cate = "Blogs";
            return View();
        }
    }
}
