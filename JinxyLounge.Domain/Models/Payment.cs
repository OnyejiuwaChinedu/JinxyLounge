using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinxyLounge.Domain.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public Product ProductId { get; set; }
        public Customer CustomerId { get; set; }
        public string Payment_type { get; set; }

        [DataType("decimal(16, 8)")]
        public Decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Phone { get; set; }
        public string Description { get; set; }

        //public string CardNumber { get; set; }

    }
}
//payment