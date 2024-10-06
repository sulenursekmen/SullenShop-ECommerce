using SullensShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Results.ProductResults
{
    public class GetProductListWithCategoryQueryResult
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetailName { get; set; }
        public Category Category { get; set; }
        public CategoryDetail CategoryDetail { get; set; }
    }
}
