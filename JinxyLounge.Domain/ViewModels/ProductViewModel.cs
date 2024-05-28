using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Domain.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public DateTime Mfg_Date { get; set; }

        public DateTime Exp_Date { get; set; }

        public List<string> ImageIDs { get; set; }

        public List<ProductImage> ProductImages { get; set; }
    }
}
