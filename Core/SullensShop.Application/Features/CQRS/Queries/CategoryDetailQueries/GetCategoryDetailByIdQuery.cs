using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Queries.CategoryDetailQueries
{
    public class GetCategoryDetailByIdQuery
    {
        public GetCategoryDetailByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
