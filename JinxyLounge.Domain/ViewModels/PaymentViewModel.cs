using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinxyLounge.Domain.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public Decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Phone { get; set; }
        public string Description { get; set; }

        public string Payment_type { get; set; }
    }
}
