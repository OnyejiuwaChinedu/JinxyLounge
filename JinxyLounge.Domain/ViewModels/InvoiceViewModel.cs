using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Domain.ViewModels
{
    public class InvoiceViewModel
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Product ProductId { get; set; }
        public Order OrderId { get; set; }
        public string Description { get; set; }
    }
}
