using System;
using System.Collections.Generic;
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
    public class EmployeeController : Controller
    {
        public EmployeeController() { }

        private IEmployeeRepository repository;
        private IEmployeeTypeRepository employeeTypeRepository;
        public int PageSize = 10;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeTypeRepository employeeTypeRepository)
        {
            this.repository = employeeRepository;
            this.employeeTypeRepository = employeeTypeRepository;
        }
        public ActionResult Index()
        {
            EmployeeListViewModel model = new EmployeeListViewModel();

            model.Employees = repository.GetAllEmployees;

            model.EmployeeTypes = employeeTypeRepository.GetAllEmployeeTypes;

            return View(model);
        }

        [HttpPost]
        public JsonResult AddEmployee(EmployeeViewModel model)
        {
            Employee employee = new Employee();

            //var employeetTypes = employeeTypeRepository.GetAllEmployeeTypes;

            employee.Name = model.Name;
            employee.Phone = model.Phone;
            employee.Email = model.Email;
            employee.Address = model.Address;
            employee.Date_Of_Birth = model.Date_Of_Birth;
            employee.Age = model.Age;
            employee.Start_Date = model.Start_Date;
            employee.EmployeeTypeId = model.EmployeeTypeId;


            repository.SaveEmployee(employee);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var employee = repository.GetEmployeeById(ID);

            repository.DeleteEmployee(employee);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditEmployeeModel model)
        {
            var employee = repository.GetEmployeeById(model.ID);

            employee.Name = model.Name;
            employee.Phone = model.Phone;
            employee.Email = model.Email;
            employee.Address = model.Address;
            employee.Date_Of_Birth = model.Date_Of_Birth;
            employee.Age = model.Age;
            employee.Start_Date = model.Start_Date;
           

            repository.UpdateEmployee(employee);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }

        public ActionResult Details(int id)
        {
            var employee = repository.GetEmployeeById(id);
            return View(employee);
        }
          
    }
}