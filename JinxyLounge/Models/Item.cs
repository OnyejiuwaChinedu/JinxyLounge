﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Models
{
    public class Item
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}