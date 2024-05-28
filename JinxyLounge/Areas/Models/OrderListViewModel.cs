using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Areas.Models
{
    public class OrderListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public int Id { get; set; }
        public Customer CustomerId { get; set; }
       
        public string Name { get; set; }
       
        public string Order_date { get; set; }

        public string Quantity { get; set; }

        public DateTime Pick_up_date { get; set; }

        public Decimal Amount { get; set; }

        public string Address { get; set; }
    }
}