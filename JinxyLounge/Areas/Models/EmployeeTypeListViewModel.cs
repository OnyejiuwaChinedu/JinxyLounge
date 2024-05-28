using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Areas.Models
{
    public class EmployeeTypeListViewModel
    {
        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
        //public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
    }
    public class EmployeeTypeActionViewModel
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
    