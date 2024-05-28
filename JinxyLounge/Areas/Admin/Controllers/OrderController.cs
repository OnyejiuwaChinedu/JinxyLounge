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
    public class OrderController : Controller
    {
        public OrderController() { }

        private IOrderRepository repository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.repository = orderRepository;
        }


        public ActionResult Index()
        {
            OrderListViewModel model = new OrderListViewModel();

            model.Orders = repository.GetAllOrder();

            return View(model);
        }
        [HttpPost]
        public JsonResult AddOrder(OrderViewModel model)
        {
            Order order = new Order();

            //var employeetTypes = employeeTypeRepository.GetAllEmployeeTypes;

            order.Name = model.Name;
            order.Order_date = model.Order_date;
            order.Quantity = model.Quantity;
            order.Pick_up_date = model.Pick_up_date;
            order.Amount = model.Amount;
            order.Address = model.Address;

            repository.SaveOrder(order);

            return Json(new
            {
                message = "Successfully added ",
                success = "true"
            });
        }

        [HttpPost]
        public JsonResult Deleted(int ID)
        {

            var order = repository.GetOrderById(ID);

            repository.DeleteOrder(order);

            return Json(new
            {
                message = "Deleted Succesfully ",
                success = "true"
            });
        }

        //new edited
        [HttpPost]
        public JsonResult Edited(EditOrderModel model)
        {
            var order = repository.GetOrderById(model.Id);

            order.Name = model.Name;
            order.Order_date = model.Order_date;
            order.Quantity = model.Quantity;
            order.Pick_up_date = model.Pick_up_date;
            order.Amount = model.Amount;
            order.Address = model.Address;


            repository.UpdateOrder(order);

            return Json(new
            {
                message = "Updated Succesfully ",
                success = "true"
            });
        }
    }
}