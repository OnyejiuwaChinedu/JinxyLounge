using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JinxyLounge.Domain.Abstract;

namespace JinxyLounge.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.GetAllProducts
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);

            return PartialView(categories);

        }
    }
}
