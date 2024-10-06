﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Domain.Entities
{
    public class ProductDetail
    {
        public string ProductDetailId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
