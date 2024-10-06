using SullensShop.Application.Features.CQRS.Commands.CategoryDetailCommands;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;

namespace SullensShop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class UpdateCategoryDetailCommandHandler
    {
        private readonly IRepository<CategoryDetail> _repository;

        public UpdateCategoryDetailCommandHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryDetailCommand updateCategoryDetailCommand)
        {
            var value = await _repository.GetByIdAsync(updateCategoryDetailCommand.CategoryDetailId);
            value.CategoryDetailId = updateCategoryDetailCommand.CategoryDetailId;
            value.CategoryDetailName = updateCategoryDetailCommand.CategoryDetailName;
            value.CategoryId = updateCategoryDetailCommand.CategoryId;
            value.ImageUrl = updateCategoryDetailCommand.ImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
