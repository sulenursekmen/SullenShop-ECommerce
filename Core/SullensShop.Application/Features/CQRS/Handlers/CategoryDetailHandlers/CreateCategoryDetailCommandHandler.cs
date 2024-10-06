using SullensShop.Application.Features.CQRS.Commands.CategoryDetailCommands;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;

namespace SullensShop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class CreateCategoryDetailCommandHandler
    {
        private readonly IRepository<CategoryDetail> _repository;

        public CreateCategoryDetailCommandHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCategoryDetailCommand createCategoryDetailCommand)
        {
            await _repository.CreateAsync(new CategoryDetail
            {
                CategoryDetailName = createCategoryDetailCommand.CategoryDetailName,
                CategoryId = createCategoryDetailCommand.CategoryId,
                ImageUrl = createCategoryDetailCommand.ImageUrl,
            });
        }
    }
}
