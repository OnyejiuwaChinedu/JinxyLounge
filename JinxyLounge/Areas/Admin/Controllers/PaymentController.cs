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
    public class PaymentController : Controller
    {
        // GET: Admin/Payment
        public PaymentController() { }

        private IPaymentRepository repository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            this.repository = paymentRepository;
        }

        public ActionResult Index()
        {

            PaymentListViewModel model = new PaymentListViewModel();

            model.Payments = repository.GetAllPayment();

            return View(model);          

        }
        [HttpPost]
        public JsonResult AddPayment(PaymentViewModel model)
        {
            Payment payment = new Payment();

            //var employeetTypes = employeeTypeRepository.GetAllEmployeeTypes;

            payment.Amount = model.Amount;
            payment.Currency = model.Currency;
            payment.Phone = model.Phone;
            payment.Description = model.Description;
            payment.Payment_type = model.Payment_type;       

            repository.SavePayment(payment);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var payment = repository.GetPaymentById(ID);

            repository.DeletePayment(payment);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditPaymentModel model)
        {
            var payment = repository.GetPaymentById(model.Id); 

            payment.Amount = model.Amount;
            payment.Currency = model.Currency;
            payment.Phone = model.Phone;
            payment.Description = model.Description;
            payment.Payment_type = model.Payment_type;


            repository.UpdatePayment(payment);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }
    
    }
}