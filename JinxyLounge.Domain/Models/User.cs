using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JinxyLounge.Domain.Entities
{
    public class User
    {
        [Key]

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string State { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}

