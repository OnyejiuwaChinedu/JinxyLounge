using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Areas.Models
{
    public class PaymentListViewModel
    {
        
        public IEnumerable<Payment> Payments { get; set; }
        public Decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Phone { get; set; }
        public string Description { get; set; }

        public string Payment_type { get; set; }

    }
}