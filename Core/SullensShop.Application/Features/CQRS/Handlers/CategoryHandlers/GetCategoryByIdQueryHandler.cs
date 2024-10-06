using SullensShop.Application.Features.CQRS.Queries.CategoryQueries;
using SullensShop.Application.Features.CQRS.Results.CategoryResults;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery getCategoryByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getCategoryByIdQuery.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = value.CategoryId, 
                CategoryName=value.CategoryName,
                ImageUrl=value.ImageUrl,
            };
        }
    }
}
