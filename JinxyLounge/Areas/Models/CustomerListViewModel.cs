using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Areas.Models
{
    public class CustomerListViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}