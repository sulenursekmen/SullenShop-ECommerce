using MediatR;
using SullensShop.Application.Features.CQRS.Commands.CategoryDetailCommands;
using SullensShop.Application.Features.CQRS.Commands.ProductCommands;
using SullensShop.Application.Features.CQRS.Queries.ProductQueries;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductListWithCategoryQueryHandler 
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<CategoryDetail> _categoryDetailRepository;

        public GetProductListWithCategoryQueryHandler(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IRepository<CategoryDetail> categoryDetailRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _categoryDetailRepository = categoryDetailRepository;
        }

        public async Task<List<GetProductListWithCategoryQuery>> Handle()
        {
            var products = await _productRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDetails = await _categoryDetailRepository.GetAllAsync();

            var query = from a in products
                        join b in categories on a.CategoryId equals b.CategoryId
                        join c in categoryDetails on a.CategoryDetailId equals c.CategoryDetailId
                        select new GetProductListWithCategoryQuery
                        {
                            ProductId = a.ProductId,
                            CategoryName = b.CategoryName,
                            ProductName = a.ProductName,
                            CategoryDetailName = c.CategoryDetailName,
                        
                        };
            return query.ToList();
        }


    }

}
