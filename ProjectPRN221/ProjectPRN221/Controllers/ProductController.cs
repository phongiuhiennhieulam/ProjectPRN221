using Microsoft.AspNetCore.Mvc;
using ProjectPRN221.Models;
using System.Linq;
using System;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectPRN221.Controllers
{
    public class ProductController : Controller
    {
        Project_SU23Context obj = new Project_SU23Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductHome(string search, int page = 1, int pageSize = 9)
        {
            var listProduct = obj.Products.OrderByDescending(x => x.ProductId).ToPagedList(page, pageSize);
            if (!String.IsNullOrEmpty(search))
            {
                listProduct = obj.Products.OrderByDescending(x => x.ProductId).Where(n => n.ProductName.Contains(search)).ToPagedList(page, pageSize);
            }
            var listCategory = obj.Categories.ToList();
            var listColor = obj.Colors.ToList();
            var listSlide = obj.Slides.ToList();
            var listPrecomment = obj.Products.Where(m => m.CategoryId == 1).ToList();
            ViewBag.listPrecomment = listPrecomment;
            ViewBag.listColor = listColor;
            ViewBag.listProduct = listProduct;
            ViewBag.listCategory = listCategory;
            ViewBag.listSlide = listSlide;
            if (HttpContext.Session.GetString("account") != null)
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                ViewBag.acc = acc;
            }
            return View();
        }
        [HttpGet]
        public IActionResult ProductByCategory(int Id)
        {
            var listProductByCategory = obj.Products.Where(n => n.CategoryId == Id).ToList();
            var listC = obj.Categories.ToList();
            var listColor = obj.Colors.ToList();
            //var listImage = objCategory..ToList();
            var listP = obj.Products.ToList();
            var listPrecomment = obj.Products.Where(m => m.CategoryId ==    2).ToList();
            ViewBag.listPrecomment = listPrecomment;
            ViewBag.listProductByCate = listProductByCategory;
            ViewBag.listCategory = listC;
            ViewBag.listColor = listColor;
            //p1.listI = listImage;
            ViewBag.listP = listP;
            return View();
        }
        [HttpGet]
        public IActionResult ProductByColor(int Id)
        {
            var listProductByColor = obj.Products.Where(n => n.ColorId == Id).ToList();
            var listC = obj.Categories.ToList();
            var listColor = obj.Colors.ToList();
            //var listImage = objCategory..ToList();
            var listPrecomment = obj.Products.Where(m => m.CategoryId == 3).ToList();
            var listPrecomment1 = obj.Products.Where(m => m.CategoryId == 1).ToList();
            ViewBag.listPrecomment = listPrecomment;
            ViewBag.listPrecomment1 = listPrecomment1;
            var listP = obj.Products.ToList();
            ViewBag.ListProductByColor = listProductByColor;
            ViewBag.listCategory = listC;
            ViewBag.listColor = listColor;
            //p1.listI = listImage;
            ViewBag.listProduct = listP;
            return View();
        }
        [HttpGet]
        public IActionResult ProductDetail(int Id)
        {
            var objProductbyId = obj.Products.Where(n => n.ProductId == Id).FirstOrDefault();
            //var objImg = obj.Image_product.Where(x => x.id == objProduct.image_id).FirstOrDefault();
            var listCategory = obj.Categories.ToList();
            var listColor = obj.Colors.ToList();
            var listProduct = obj.Products.Where(x=>x.CategoryId ==2).ToList();
            var listSize = obj.Sizes.ToList();
            ProductDetail p = new ProductDetail();
            p.objProduct = objProductbyId;
            var listPrecomment = obj.Products.Where(m => m.CategoryId == 1).ToList();
            ViewBag.listPrecomment = listPrecomment;

            //productDetail.objImage = objImg;
            ViewBag.lstCategory = listCategory;
            ViewBag.lstColor = listColor;
            ViewBag.lstProduct = listProduct;
            ViewBag.lstSize = listSize;
            ViewBag.lstSize = listSize;
            return View(p);

        }
        [HttpGet]
        public IActionResult SearchProduct(string search, string result = "product", int page = 1, int pageSize = 3)
        {
            var lstPro = obj.Products.Where(x => x.ProductName.Contains(search)).OrderByDescending(x => x.ProductName).ToPagedList(page, pageSize);
            var lstBlog = obj.Blogs.Where(x => x.BlogTitle.Contains(search)).OrderByDescending(x => x.BlogCreatedate).ToPagedList(page, pageSize);
            var product = obj.Products.ToList();
            var listPrecomment = obj.Products.Where(m => m.CategoryId == 1).ToList();
            ViewBag.listPrecomment = listPrecomment;
            ViewBag.lstBlog = lstBlog;
            ViewBag.lstPro = lstPro;
            ViewBag.search = search;
            ViewBag.result = result;
            ViewBag.ListProduct = product;
           

            return View();
        }
        [HttpGet]
        public IActionResult Blog (int page = 1, int pageSize = 4)
        {
            var blog = obj.Blogs.OrderByDescending(x => x.BlogCreatedate).ToPagedList(page, pageSize);
            var cate = obj.Categories.ToList();
            var color = obj.Colors.ToList();
            var pro = obj.Products.Where(n=>n.CategoryId == 1).ToList();
            var listPrecomment = obj.Products.Where(m => m.CategoryId == 2).ToList();
            ViewBag.listPrecomment = listPrecomment;
            ViewBag.blog = blog;
            ViewBag.cate = cate;
            ViewBag.color = color;
            ViewBag.ListProducts = pro;
            return View();
        }
        [HttpGet]
        public IActionResult BlogDetail(int Id)
        {
            var blog = obj.Blogs.Where(x => x.BlogId == Id).FirstOrDefault();
            var relateBlog = obj.Blogs.Where(x => x.BlogId == Id - 1).FirstOrDefault();
            if (Id == 1)
            {
                relateBlog = obj.Blogs.Where(x => x.BlogId == Id + 1).FirstOrDefault();
            }
            var cate = obj.Categories.ToList();
            var color = obj.Colors.ToList();
            var pro = obj.Products.Where(n=>n.CategoryId==1).ToList();

            ProductDetail bg = new ProductDetail();
            var listPrecomment = obj.Products.Where(m => m.CategoryId == 1).ToList();
            ViewBag.listPrecomment = listPrecomment;
            bg.bg = blog;
            bg.relateBlog = relateBlog;
            ViewBag.cate = cate;
            ViewBag.color = color;
            ViewBag.ListProducts = pro;
            return View(bg);
        }

        public IActionResult AddToCart(int Id)
        {
            bool isExist = false;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                var pro = obj.Products.FirstOrDefault(x => x.ProductId == Id);
                foreach (var item in obj.CartDetails.ToList()) 
                {
                    if (item.ProductId == Id)
                    {
                        isExist = true;
                    }
                }
                if (isExist == false)
                {
                    var c = obj.Carts.FirstOrDefault(x => x.AccountId == acc.AccountId);
                    if (c == null) {
						Cart ca = new Cart
						{
							AccountId = acc.AccountId,
							CartTotol = pro.ProductPrice
						};
						obj.Carts.Add(ca);
						obj.SaveChanges();
					}

                    var car = obj.Carts.FirstOrDefault(x => x.AccountId == acc.AccountId);
					CartDetail cd = new CartDetail
					{
						CartId = car.CartId,
						ProductId = Id,
						Quantity = 1,
						Price = pro.ProductPrice,
					};
                    obj.CartDetails.Add(cd);
                    obj.SaveChanges();
				} else
                {
                    var cd = obj.CartDetails.FirstOrDefault(x => x.ProductId == Id);
                    cd.Quantity = cd.Quantity + 1;
                    obj.Entry(cd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    obj.SaveChanges();
                }
                return RedirectToAction("ListCart");
			}
        }

        [HttpPost]
        public IActionResult Order(int Id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                if (Id == null)
                {
                    ViewBag.acc = acc;
                    ViewBag.cart = "Cart empty choose something to order";
					return View("ListCart");
				}
				//var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
				var cart1 = obj.Carts.FirstOrDefault(x => x.CartId == Id);
				if (cart1 == null)
                {
                    ViewBag.acc = acc;
                    ViewBag.cart = "Cart empty choose something to order";
                    return View("ListCart");
                }

                var cart = obj.Carts.FirstOrDefault(x => x.CartId == Id);
                var cartDetail = obj.CartDetails.Include(x => x.Product).Where(x => x.CartId == Id).ToList();
                Order order = new Order
                {
                    AccountId = acc.AccountId, 
                    OrderStatusId = 1, 
                    OrderNote = "Oke", 
                    OrderTotalMoney = (float)cart.CartTotol, 
                    OrderDate = DateTime.Now, 
                    ShippingId = 1,
                };
                obj.Orders.Add(order);
                obj.SaveChanges();

                foreach (var item in cartDetail)
                {
                    var or = obj.Orders.OrderBy(x => x.OrderDate).LastOrDefault();
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderId = or.OrderId,
                        ProductId = item.ProductId,
                        OrderDetailsPrice = item.Product.ProductPrice, 
                        OrderDetailsNum = item.Quantity, 
                        OrderDetailsTotalNumber = item.Quantity
                    };
                    obj.OrderDetails.Add(orderDetail);
                    obj.SaveChanges();
                }

                obj.CartDetails.RemoveRange(cartDetail);
                obj.SaveChanges();
                obj.Carts.Remove(cart);
                obj.SaveChanges();
                return RedirectToAction("ToPay", "User");
            }
        }

        public IActionResult ListCart()
        {
            //bool isExist = false;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                var lst = obj.Carts.FirstOrDefault(x => x.AccountId == acc.AccountId);
                var lstCart = obj.CartDetails.ToList();
                ViewBag.lstProduct = obj.Products.ToList();
                ViewBag.lstCart = lstCart;
                ViewBag.lst = lst;
                ViewBag.acc = acc;
                return View();
            }
        }

        public IActionResult DeleteCart(int PId, int CId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("account")))
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCartOrder = obj.CartDetails.FirstOrDefault(x => x.ProductId == PId && x.CartId == CId);
                obj.CartDetails.Remove(lstCartOrder);
                obj.SaveChanges();
                return RedirectToAction("ListCart");
            }
        }

    }
}
