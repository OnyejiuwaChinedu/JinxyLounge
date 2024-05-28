using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Product ProductId { get; set; } 
        public Order OrderId { get; set; }
        public string Description { get; set; }

    }
}
