using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinxyLounge.Domain.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
     
        public string Name { get; set; }

        public string Order_date { get; set; }

        public string Quantity { get; set; }

        public DateTime Pick_up_date { get; set; }

        public Decimal Amount { get; set; }

        public string Address { get; set; }
    }
}
