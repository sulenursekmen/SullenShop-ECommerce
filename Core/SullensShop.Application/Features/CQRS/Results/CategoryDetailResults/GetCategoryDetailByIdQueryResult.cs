using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Results.CategoryDetailResults
{
    public class GetCategoryDetailByIdQueryResult
    {
        public int CategoryDetailId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDetailName { get; set; }
        public string ImageUrl { get; set; }
    }
}
