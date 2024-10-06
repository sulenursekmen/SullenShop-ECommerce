using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Domain.Entities
{
    public class CategoryDetail
    {
        public int CategoryDetailId { get; set; }
        public int CategoryId { get; set; } 
        public string CategoryDetailName { get; set; }
        public List<Product> Products { get; set; }
    }
}
