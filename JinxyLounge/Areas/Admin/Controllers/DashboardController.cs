using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JinxyLounge.Areas.Models;
using JinxyLounge.Domain.Concrete;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
       // GET: Admin/Dashboard
       EFImageRepository ImageRepo = new EFImageRepository();

        public ActionResult Index()
        {
            ImageViewModel model = new ImageViewModel
            {
                Images = ImageRepo.GetAllImages
            };
            return View();
        }


        [HttpPost]
        public JsonResult UploadImages()
        {
            JsonResult result = new JsonResult();

            var imgList = new List<ProImage>();



            var files = Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                var image = files[i];

                var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var filePath = Server.MapPath("~/Images/") + fileName;

                image.SaveAs(filePath);

                var dbImage = new ProImage();
                dbImage.URL = fileName;

                if (ImageRepo.SaveImage(dbImage))
                {
                    imgList.Add(dbImage);
                }
            }

            result.Data = imgList;

            return result;
        }
    }
}