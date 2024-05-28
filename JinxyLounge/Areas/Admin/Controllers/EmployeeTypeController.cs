using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JinxyLounge.Areas.Models;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Domain.EditModels;
using JinxyLounge.Domain.Models;
using JinxyLounge.Domain.ViewModels;

namespace JinxyLounge.Areas.Admin.Controllers
{
    public class EmployeeTypeController : Controller
    {
        public EmployeeTypeController() { }

        private IEmployeeTypeRepository repository;

        public EmployeeTypeController(IEmployeeTypeRepository typeRepository)
        {
            this.repository = typeRepository;
        }
        public ActionResult Index()
        {
            EmployeeTypeListViewModel model = new EmployeeTypeListViewModel();

            model.EmployeeTypes = repository.GetAllEmployeeTypes;

            //model.EmployeeTypes = employeeTypeRepository.GetAllEmployeeTypes;

            return View(model);
        }

        [HttpPost]
        public JsonResult AddEmployeeType(EmployeeTypeViewModel model)
        {
            EmployeeType employeeType = new EmployeeType();

            //var employeetTypes = employeeTypeRepository.GetAllEmployeeTypes;

            employeeType.Id = model.Id;
            employeeType.TypeName = model.TypeName;

            repository.SaveEmployeeType(employeeType);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var employeeType = repository.GetEmployeeTypeById(ID);   

            repository.DeleteEmployeeType(employeeType);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditEmployeeTypeModel model)
        {
            var employeeType = repository.GetEmployeeTypeById(model.Id);

            employeeType.Id = model.Id;
            employeeType.TypeName = model.TypeName;



            repository.UpdateEmployeeType(employeeType);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }
    }   
}
        