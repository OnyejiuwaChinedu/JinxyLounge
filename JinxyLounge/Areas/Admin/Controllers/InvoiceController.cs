using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JinxyLounge.Areas.Models;
using JinxyLounge.Domain;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Domain.EditModels;
using JinxyLounge.Domain.ViewModels;

namespace JinxyLounge.Areas.Admin.Controllers
{
    public class InvoiceController : Controller
    {
        public InvoiceController() { }

        private IInvoiceRepository repository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            this.repository = invoiceRepository;
        }

        public ActionResult Index()
        {
            InvoiceListViewModel model = new InvoiceListViewModel();

            model.Invoices = repository.GetAllInvoice();

            return View(model);
           
        }
        [HttpPost]
        public JsonResult AddInvoice(InvoiceViewModel model)
        {
            Invoice invoice = new Invoice();

            //var employeetTypes = employeeTypeRepository.GetAllEmployeeTypes;

            invoice.Name = model.Name;
            invoice.Description = model.Description;

            repository.SaveInvoice(invoice);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }
        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var invoice = repository.GetInvoiceById(ID);

            repository.DeleteInvoice(invoice);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditInvoiceModel model)
        {
            var invoice = repository.GetInvoiceById(model.Id);

            invoice.Name = model.Name;
            invoice.Description = model.Description;


            repository.UpdateInvoice(invoice);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }
    }
}