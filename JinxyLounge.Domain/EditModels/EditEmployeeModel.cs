using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinxyLounge.Domain.EditModels
{
    public class EditEmployeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public int Age { get; set; }
        public DateTime Start_Date { get; set; }
        public int EmployeeTypeId { get; set; }
    }
}
