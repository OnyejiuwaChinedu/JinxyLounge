using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinxyLounge.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Customer CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter date")]
        public string Order_date { get; set; }

        public string Quantity { get; set; }

        public DateTime Pick_up_date { get; set; }
        [Required(ErrorMessage = "Please enter Amount")]

        public Decimal Amount { get; set; }

        public string Address { get; set; }

    }
}
