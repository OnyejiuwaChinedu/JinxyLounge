using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JinxyLounge.Areas.Models;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Domain.EditModels;
using JinxyLounge.Domain.Entities;
using JinxyLounge.Domain.ViewModels;

namespace JinxyLounge.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController() { }

        private ICustomerRepository repository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.repository = customerRepository;
        }
        public ActionResult Index()
        {

            CustomerListViewModel model = new CustomerListViewModel();

            model.Customers = repository.GetAllCustomers();

            return View(model);
            
        }
        [HttpPost]
        public JsonResult AddCustomer(CustomerViewModel model)
        {
            Customer customer = new Customer();

            //var employeetTypes = employeeTypeRepository.GetAllEmployeeTypes;

            customer.LastName = model.LastName;
            customer.FirstName = model.FirstName;
            customer.Phone = model.Phone;
            customer.Address = model.Address;
            customer.Email = model.Email;

            repository.SaveCustomer(customer);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var customer = repository.GetCustomerById(ID);

            repository.DeleteCustomer(customer);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditCustomerModel model)
        {
            var customer = repository.GetCustomerById(model.Id);

            customer.LastName = model.LastName;
            customer.FirstName = model.FirstName;
            customer.Phone = model.Phone;
            customer.Address = model.Address;
            customer.Email = model.Email;


            repository.UpdateCustomer(customer);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }

    }
}