using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JinxyLounge.Areas.ViewModels;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Domain.Concrete;
using JinxyLounge.Domain.EditModels;
using JinxyLounge.Domain.Entities;
using JinxyLounge.Domain.Models;
using JinxyLounge.Domain.ViewModels;
using JinxyLounge.Models;

namespace JinxyLounge.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public ProductController() { }
        private IProductRepository repository;
        public int PageSize = 30;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public ActionResult Index(string category, int page = 1)
        {
            ProductListViewModels model = new ProductListViewModels
            {
                Products = repository.GetAllProducts
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.GetAllProducts.Count() :
                    repository.GetAllProducts.Where(e => e.Category == category).Count()
                },
            };
            return View(model);
        }

        //[HttpGet]
        //public ActionResult Action(int? Id)
        //{
        //    ProductActionModel model = new ProductActionModel();
        //    if (Id.HasValue) //we are trying to edit a record
        //    {
        //        var product = repository.GetProductById(Id.Value);
        //        model.Id = product.Id;
        //        model.Name = product.Name;
        //        model.Price = product.Price;
        //        model.Description = product.Description;
        //        model.Category = product.Category;
        //        model.Mfg_Date = product.Mfg_Date;
        //        model.Exp_Date = product.Exp_Date;
        //    }
        //    return PartialView("_Action", model);
        //}

        //[HttpPost]
        //public JsonResult Action(ProductActionModel model)
        //{
        //    JsonResult json = new JsonResult();
        //    var result = false;

        //    if (model.Id > 0) //we are trying to edit a record
        //    {
        //        var product = repository.GetProductById(model.Id);

        //        product.Id = model.Id;
        //        product.Name = model.Name;
        //        product.Price = model.Price;
        //        product.Description = model.Description;
        //        product.Category = model.Category;
        //        product.Mfg_Date = model.Mfg_Date;
        //        product.Exp_Date = model.Exp_Date;

        //        repository.UpdateProduct(product);
        //    }
        //    else //we are trying to create a record
        //    {
        //        Product product = new Product();

        //        //product.Id = model.Id;
        //        product.Name = model.Name;
        //        product.Price = model.Price;
        //        product.Description = model.Description;
        //        product.Category = model.Category;
        //        product.Mfg_Date = model.Mfg_Date;
        //        product.Exp_Date = model.Exp_Date;

        //        repository.SaveProduct(product);
        //    }

        //    if (result)
        //    {
        //        json.Data = new { Success = true };
        //    }
        //    else
        //    {
        //        json.Data = new { Success = false, Message = "Unable to perform action on Products." };
        //    }

        //    return json;
        //}

        //New AddProduct
        [HttpPost]
        public JsonResult AddProduct(ProductViewModel model)
        {

            var efImageRepo = new EFImageRepository();
            var list = model.ImageIDs;
            var imgIDs = string.Join(",", list);

            List<int> imageIDs = !string.IsNullOrEmpty(imgIDs) ? model.ImageIDs.Select(x => int.Parse(x)).ToList() : new List<int>();

            var images = efImageRepo.GetImagesByIDs(imageIDs);


            Product product = new Product();
            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Category = model.Category;
            product.Mfg_Date = model.Mfg_Date;
            product.Exp_Date = model.Exp_Date;
            product.ProductURL = images.Select(x => x.URL).FirstOrDefault();


            product.ProductImages = new List<ProductImage>();
            product.ProductImages.AddRange(images.Select(x => new ProductImage() { ProductID = product.Id, ImageID = x.ID }));


            repository.SaveProduct(product);

            return Json(new
            {
                message = "Successfully added ", success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int id)
        {

            var product = repository.GetProductById(id);

            repository.DeleteProduct(product);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });           
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditViewModels model)
        {

            var efImageRepo = new EFImageRepository();
            var list = model.ImageIDs;
            var imgIDs = string.Join(",", list);

            List<int> imageIDs = !string.IsNullOrEmpty(imgIDs) ? model.ImageIDs.Select(x => int.Parse(x)).ToList() : new List<int>();

            var images = efImageRepo.GetImagesByIDs(imageIDs);
            var product = repository.GetProductById(model.Id);

            product.Id = model.Id;
            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Category = model.Category;
            product.ProductURL = images.Select(x => x.URL).FirstOrDefault();

            product.ProductImages.AddRange(images.Select(x => new ProductImage() { ProductID = product.Id, ImageID = x.ID }));


            DateTime Mdate;
            bool isMfgDate = DateTime.TryParse(model.Mfg_Date,out Mdate);

            if (isMfgDate)
                product.Mfg_Date = Mdate;


            DateTime Edate;
            bool isEfDate = DateTime.TryParse(model.Mfg_Date, out Edate);

            if (isEfDate)
                product.Exp_Date = Edate;


            repository.UpdateProduct(product);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }
    }
}