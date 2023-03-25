using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ProjectPRN221.Models;
using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using X.PagedList;

namespace ProjectPRN221.Controllers
{
    public class AdminController : Controller
    {
        Project_SU23Context shopDB = new Project_SU23Context();
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
                {
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        [HttpGet]
        public IActionResult Product(string search = null, int page=1, int pageSize = 5 )
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
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
                    if (HttpContext.Session.GetString("product") != null)
                    {
                        ViewBag.mess = HttpContext.Session.GetString("product");
                    }
                    if (HttpContext.Session.GetString("editpro") != null)
                    {
                        ViewBag.mess = HttpContext.Session.GetString("editpro");
                    }
                    if (HttpContext.Session.GetString("delepro") != null)
                    {
                        ViewBag.mess = HttpContext.Session.GetString("delepro");
                    }
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
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
                return RedirectToAction("", "");
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddProduct(Product product) 
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
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
                    HttpContext.Session.SetString("product", "Add product successfull");
                    return RedirectToAction("Product");
                }
                return RedirectToAction("", "");
            }
        }

        public IActionResult EditProduct(int Id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
                {
                    var product = shopDB.Products.FirstOrDefault(x => x.ProductId == Id);
                    var lstCategory = shopDB.Categories.ToList();
                    var lstColor = shopDB.Colors.ToList();
                    var lstStatusProduct = shopDB.StatusProducts.ToList();
                    ViewBag.product = product;
                    ViewBag.CategoryId = new SelectList(lstCategory, "CategoryId", "CategoryName", product.CategoryId);
                    ViewBag.ColorId = new SelectList(lstColor, "ColorId", "ColorName", product.ColorId);
                    ViewBag.StatusProductId = new SelectList(lstStatusProduct, "StatusProductId", "StatusProductStatus", product.StatusProductId);
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditProduct(int proId, Product product)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
                {
                    if (!ModelState.IsValid)
                    {
                        ViewBag.product = shopDB.Products.FirstOrDefault(x => x.ProductId == proId);
                        var lstCategory = shopDB.Categories.ToList();
                        var lstColor = shopDB.Colors.ToList();
                        var lstStatusProduct = shopDB.StatusProducts.ToList();
                        ViewBag.product = product;
                        ViewBag.CategoryId = new SelectList(lstCategory, "CategoryId", "CategoryName", product.CategoryId);
                        ViewBag.ColorId = new SelectList(lstColor, "ColorId", "ColorName", product.ColorId);
                        ViewBag.StatusProductId = new SelectList(lstStatusProduct, "StatusProductId", "StatusProductStatus", product.StatusProductId);
                        return View("EditProduct");
                    }

                    shopDB.Entry(product).State = EntityState.Modified;
                    shopDB.SaveChanges();
                    HttpContext.Session.SetString("editpro", "Edit product successfull");
                    return RedirectToAction("Product");
                }
                return RedirectToAction("", "");
            }
        }

        public IActionResult DeleteProduct(int Id)
        {
            Product pro = shopDB.Products.FirstOrDefault(x => x.ProductId == Id);
            if (pro != null)
            {
                shopDB.Products.Remove(pro);
                shopDB.SaveChanges();
                HttpContext.Session.SetString("delepro", "Delete product successfull");
            }
            return RedirectToAction("Product");
        }

        public IActionResult Blog(string search, int page=1, int pageSize = 5)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
                {
                    var lstBlog = shopDB.Blogs.ToList().ToPagedList(page, pageSize);
                    if (search != null)
                    {
                        lstBlog = lstBlog.Where(x => x.BlogTitle.ToLower().Contains(search.ToLower())).ToList().ToPagedList(page, pageSize);
                    }
                    //lstBlog = lstBlog.OrderByDescending(x => x.BlogCreatedate).ToList().ToPagedList(page, pageSize);
                    ViewBag.lstBlog = lstBlog;
                    if (HttpContext.Session.GetString("blog") != null)
                    {
                        ViewBag.mess = HttpContext.Session.GetString("blog");
                        HttpContext.Session.SetString("blog", null); 
                    }
                    if (HttpContext.Session.GetString("editblog") != null)
                    {
                        ViewBag.mess = HttpContext.Session.GetString("editblog");
                    }
                    if (HttpContext.Session.GetString("deleblog") != null)
                    {
                        ViewBag.mess = HttpContext.Session.GetString("deleblog");
                    }
                    ViewBag.cate = "Blogs";
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        public IActionResult AddBlog()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
                {
                    ViewBag.cate = "Blogs";
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View("AddBlog");
            }
            shopDB.Blogs.Add(blog);
            shopDB.SaveChanges();
            HttpContext.Session.SetString("blog", "Add Blog Successfull!!!");
            return RedirectToAction("Blog");
        }

        public IActionResult EditBlog(int Id)
        {
            var blog = shopDB.Blogs.FirstOrDefault(x => x.BlogId == Id);
            ViewBag.blog = blog;
            ViewBag.cate = "Blogs";
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditBlog(int BlogId, string img, string detail, string blogDetail, Blog blog)
        {
            
            if (img != null)
            {
                blog.BlogImages = img;
            }

            if (detail == null)
            {
                blog.BlogDetail = blogDetail;
            }

            if (!ModelState.IsValid)
            {
                var bl = shopDB.Blogs.FirstOrDefault(x => x.BlogId == BlogId);
                ViewBag.blog = bl;
                return View("EditBlog");
            }
            shopDB.Entry(blog).State = EntityState.Modified;
            shopDB.SaveChanges();
            HttpContext.Session.SetString("editblog", "Edit blog successfull!!!");
            return RedirectToAction("Bog");
        }

        public IActionResult DeleteBlog(int Id)
        {
            var blog = shopDB.Blogs.FirstOrDefault(x => x.BlogId == Id);
            shopDB.Blogs.Remove(blog);
            shopDB.SaveChanges();
            ViewBag.cate = "Blogs";
            HttpContext.Session.SetString("deleblog", "Delete blog successfull!!!");
            return RedirectToAction("Blog");
        }

        public IActionResult Slide(string search, int page = 1, int pageSize = 5)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
                {
                    var lstSlide = shopDB.Slides.Where(x => x.SlideStatusId == false).ToList().ToPagedList(page, pageSize);
                    var lstSlideAc = shopDB.Slides.Where(x => x.SlideStatusId == true).ToList().ToPagedList(page, pageSize);
                    if (search != null)
                    {
                        lstSlide = lstSlide.Where(x => x.SlideTitle.ToLower().Contains(search.ToLower())).ToList().ToPagedList(page, pageSize);
                        //lstSlideAc = lstSlideAc.Where(x => x.SlideTitle.ToLower().Contains(search.ToLower())).ToList().ToPagedList(page, pageSize);
                    }
                    lstSlide = lstSlide.OrderByDescending(x => x.SlideCreatedate).ToList().ToPagedList(page, pageSize);

                    ViewBag.lstSlide = lstSlide;
                    ViewBag.lstSlideAc = lstSlideAc;
                    ViewBag.search = search;
                    ViewBag.cate = "Slides";
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        public IActionResult InsertActive(int Id)
        {
            Slide slide = shopDB.Slides.FirstOrDefault(x => x.SlideId == Id);
            if (slide != null)
            {
                slide.SlideStatusId = true;
                shopDB.Entry(slide).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                shopDB.SaveChanges();
            }
            
            ViewBag.cate = "Slides";
            return RedirectToAction("Slide");
        }

        public IActionResult DeleteActive(int Id)
        {
            Slide slide = shopDB.Slides.FirstOrDefault(x => x.SlideId == Id);
            if (slide != null)
            {
                slide.SlideStatusId = false;
                shopDB.Entry(slide).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                shopDB.SaveChanges();
            }  
            ViewBag.cate = "Slides";
            return RedirectToAction("Slide");
        }

        [HttpGet]
        public IActionResult AddSlide()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
                {
                    ViewBag.date = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddSlide(Slide slide)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSlide");
            }
            slide.SlideStatusId = false;
            shopDB.Slides.Add(slide);
            shopDB.SaveChanges();
            return RedirectToAction("Slide");
        }

        public IActionResult EditSlide(int Id)
        {
            var slide = shopDB.Slides.FirstOrDefault(x => x.SlideId == Id);
            ViewBag.slide = slide;
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditSlide(int SlideId,   Slide slide)
        { 
            if (!ModelState.IsValid)
            {
                ViewBag.slide = shopDB.Slides.FirstOrDefault(x => x.SlideId == SlideId);
                return View("EditSlide");
            }
            var sl = shopDB.Slides.FirstOrDefault(x => x.SlideId == SlideId);
            if (sl != null)
            {
                sl.SlideTitle = slide.SlideTitle;
                sl.SlideDescriptions = slide.SlideDescriptions;
                sl.SlideModifyby = slide.SlideModifyby;
                sl.SlideModifydate = slide.SlideModifydate;
            }
            shopDB.Entry(sl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            shopDB.SaveChanges();
            return RedirectToAction("Slide");
        }

        public IActionResult DeleteSlide(int Id)
        {
            var slide = shopDB.Slides.FirstOrDefault(x => x.SlideId == Id);
            shopDB.Slides.Remove(slide);
            shopDB.SaveChanges();
            ViewBag.cate = "Slides";
            return RedirectToAction("Slide");
        }

        public IActionResult Customer(string search, int page = 1, int pageSize = 5)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
                {
                    var role = shopDB.Roles.FirstOrDefault(x => x.RoleName == "Customer");
                    var lstCustomer = shopDB.Accounts.Where(x => x.AccountRoleId == role.RoleId).ToList().ToPagedList(page, pageSize);
                    if (search != null)
                    {
                        lstCustomer = lstCustomer.Where(x => x.AccountName.ToLower().Contains(search.ToLower())).ToList().ToPagedList(page, pageSize);
                    }
                    ViewBag.lstCustomer = lstCustomer;
                    ViewBag.search = search;
                    ViewBag.cate = "Customers";
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        public IActionResult UnLockAccount(int Id)
        {
            Account acc = shopDB.Accounts.FirstOrDefault(x => x.AccountId == Id);
            if (acc != null)
            {
                acc.AccountStatus = true;
                shopDB.Entry(acc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                shopDB.SaveChanges();
            }
            ViewBag.cate = "Customers";
            return RedirectToAction("Customer");
        }

        public IActionResult LockAccount(int Id)
        {
            Account acc = shopDB.Accounts.FirstOrDefault(x => x.AccountId == Id);
            if (acc != null)
            {
                acc.AccountStatus = false;
                shopDB.Entry(acc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                shopDB.SaveChanges();
            }
            ViewBag.cate = "Customers";
            return RedirectToAction("Customer");
        }

        public IActionResult ViewOrderMember(int Id)
        {
            ViewBag.member = shopDB.Accounts.FirstOrDefault(x => x.AccountId == Id);
            ViewBag.lstOrder = shopDB.Orders.ToList();
            ViewBag.lstProduct = shopDB.Products.ToList();
            ViewBag.lstOrderDetail = shopDB.OrderDetails.ToList();
            ViewBag.lstOrderStatus = shopDB.OrderStatuses.ToList();
            return View();
        }

        public IActionResult Order()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("", "");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (acc.AccountRoleId == 2)
                {
                    ViewBag.lstOrder = shopDB.Orders.ToList();
                    ViewBag.lstOrderDetail = shopDB.OrderDetails.ToList();
                    ViewBag.lstProduct = shopDB.Products.ToList();
                    ViewBag.lstOrderStatus = shopDB.OrderStatuses.ToList();
                    ViewBag.lstMember = shopDB.Accounts.ToList();
                    ViewBag.cate = "Orders";
                    return View();
                }
                return RedirectToAction("", "");
            }
        }

        public IActionResult AceptOrder(int Id)
        {
            var order = shopDB.Orders.FirstOrDefault(x => x.OrderId == Id);
            order.OrderStatusId = 2;
            shopDB.Entry(order).State = EntityState.Modified;
            shopDB.SaveChanges();
            ViewBag.cate = "Orders";
            return RedirectToAction("Order");
        }

        public IActionResult CancelledOrder(int Id)
        {
            var order = shopDB.Orders.FirstOrDefault(x => x.OrderId == Id);
            order.OrderStatusId = 5;
            shopDB.Entry(order).State = EntityState.Modified;
            shopDB.SaveChanges();
            ViewBag.cate = "Orders";
            return RedirectToAction("Order");
        }

        public IActionResult Complete(int Id)
        {
            var order = shopDB.Orders.FirstOrDefault(x => x.OrderId == Id);
            order.OrderStatusId = 4;
            shopDB.Entry(order).State = EntityState.Modified;
            shopDB.SaveChanges();
            ViewBag.cate = "Orders";
            return RedirectToAction("Index");
        }

        public IActionResult SummerNote()
        {
            return View();
        }

    }
}
