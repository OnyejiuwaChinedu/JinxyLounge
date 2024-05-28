using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JinxyLounge.Domain;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Areas.Models
{
    public class InvoiceListViewModel
    {
        public IEnumerable<Invoice> Invoices {get; set;}
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Product ProductId { get; set; }
        public Order OrderId { get; set; }
        public string Description { get; set; }
    }
}