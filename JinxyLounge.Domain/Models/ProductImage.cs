﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinxyLounge.Domain.Models
{
    public class ProductImage
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int ImageID { get; set; }

        public virtual ProImage Image { get; set; }
    }
}
