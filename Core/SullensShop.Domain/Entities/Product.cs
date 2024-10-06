﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int CategoryDetailId { get; set; }
        public Category Category { get; set; }
        public CategoryDetail CategoryDetail { get; set; }
    }
}
