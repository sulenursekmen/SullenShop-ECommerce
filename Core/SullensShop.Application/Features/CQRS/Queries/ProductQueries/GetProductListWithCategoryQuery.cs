using SullensShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Queries.ProductQueries
{
    public class GetProductListWithCategoryQuery
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetailName { get; set; }

        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public decimal ProductPrice { get; set; }

        public Category Category { get; set; }  
        public CategoryDetail CategoryDetail { get; set; }

    }
}
