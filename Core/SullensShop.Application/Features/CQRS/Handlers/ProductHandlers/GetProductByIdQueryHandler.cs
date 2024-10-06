using SullensShop.Application.Features.CQRS.Queries.ProductQueries;
using SullensShop.Application.Features.CQRS.Results.ProductResults;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly IRepository<Product> _repository;

        public GetProductByIdQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery getProductByIdQuery)
        {
            var value= await _repository.GetByIdAsync(getProductByIdQuery.Id);
            return new GetProductByIdQueryResult
            {
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                CategoryId = value.CategoryId,
                CategoryDetailId=value.CategoryDetailId,
               
            };
        }
    }
}
