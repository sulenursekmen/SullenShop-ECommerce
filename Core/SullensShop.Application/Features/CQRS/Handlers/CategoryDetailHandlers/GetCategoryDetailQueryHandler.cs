using SullensShop.Application.Features.CQRS.Results.CategoryDetailResults;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;

namespace SullensShop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class GetCategoryDetailQueryHandler
    {
        private readonly IRepository<CategoryDetail> _repository;

        public GetCategoryDetailQueryHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryDetailQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetCategoryDetailQueryResult
            {
                CategoryDetailId = x.CategoryDetailId,
                CategoryDetailName = x.CategoryDetailName,
                CategoryId = x.CategoryId,
                ImageUrl = x.ImageUrl,

            }).ToList();
        }
    }
}
