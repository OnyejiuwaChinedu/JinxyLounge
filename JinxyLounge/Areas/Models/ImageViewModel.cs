using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Areas.Models
{
    public class ImageViewModel
    {
        public IEnumerable<ProImage> Images { get; set; }
    }
}