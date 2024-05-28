using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Domain.EditModels
{
    public class EditPaymentModel
    {
        public int Id { get; set; }
        public Product ProductId { get; set; }
        public Customer CustomerId { get; set; }
        public string Payment_type { get; set; }
      
        public Decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Phone { get; set; }
        public string Description { get; set; }

        public string CardNumber { get; set; }
    }
}
