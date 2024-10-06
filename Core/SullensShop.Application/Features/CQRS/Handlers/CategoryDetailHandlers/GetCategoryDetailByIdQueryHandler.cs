using SullensShop.Application.Features.CQRS.Queries.CategoryDetailQueries;
using SullensShop.Application.Features.CQRS.Results.CategoryDetailResults;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;

namespace SullensShop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class GetCategoryDetailByIdQueryHandler
    {
        private readonly IRepository<CategoryDetail> _repository;

        public GetCategoryDetailByIdQueryHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryDetailByIdQueryResult> Handle(GetCategoryDetailByIdQuery getCategoryDetailByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getCategoryDetailByIdQuery.Id);
            return new GetCategoryDetailByIdQueryResult
            {
                CategoryDetailId = value.CategoryDetailId,
                CategoryDetailName = value.CategoryDetailName,
                CategoryId=value.CategoryId,
            };
        }
    }
}
