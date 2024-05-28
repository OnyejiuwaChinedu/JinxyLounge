using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using JinxyLounge.Domain.Entities;
using JinxyLounge.Domain.Models;
using JinxyLounge.Models;

namespace JinxyLounge.Areas.ViewModels
{
    public class ProductListViewModels
    {

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        ////public ProductActionModel ProductActionModel { get; set; }

    }

    public class ProductActionModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        //[DataType(DataType.Date)]
        public DateTime Mfg_Date { get; set; }

        //[DataType(DataType.Date)]
        public DateTime Exp_Date { get; set; }
        public List<string> ImageIDs { get; set; }

        public List<ProductImage> ProductImages { get; set; }
    }
}