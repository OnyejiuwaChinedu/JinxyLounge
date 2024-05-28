using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Domain.EditModels
{
    public class EditViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Mfg_Date { get; set; }

        public string Exp_Date { get; set; }

        public List<string> ImageIDs { get; set; }

        public List<ProductImage> ProductImages { get; set; }


    }
}
