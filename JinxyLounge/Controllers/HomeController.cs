using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JinxyLounge.Areas.ViewModels;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Models;

namespace JinxyLounge.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        private IProductRepository _repository;
        public int PageSize = 30;

        public HomeController(IProductRepository productRepository)
        {
            this._repository = productRepository;
        }
        public ActionResult Index()
        {
            ProductListViewModels model = new ProductListViewModels
            {
                Products = _repository.GetAllProducts
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult AddToCart()
        //{

        //}
        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult CheckoutDetails()
        {
            return View();
        }


        public ActionResult AddToCart(int productId)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = _repository.GetProductById(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;

                Console.WriteLine(cart);
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var count = cart.Count();
                var product = _repository.GetProductById(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Product.Id == productId)
                    {
                        int prevQty = cart[i].Quantity;
                        cart.Remove(cart[i]);
                        cart.Add(new Item()
                        {
                            Product = product,
                            Quantity = prevQty + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Product.Id == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = 1
                            });
                        }
                    }
                }
                Session["cart"] = cart;
                
            }
            
            return Redirect("Index");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.Id == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Index");
        }

        public ActionResult Completed()
        {

            return View();
        }

    }
}