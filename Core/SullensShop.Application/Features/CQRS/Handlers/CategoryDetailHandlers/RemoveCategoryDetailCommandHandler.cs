using SullensShop.Application.Features.CQRS.Commands.CategoryDetailCommands;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;

namespace SullensShop.Application.Features.CQRS.Handlers.CategoryDetailHandlers
{
    public class RemoveCategoryDetailCommandHandler
    {
        private readonly IRepository<CategoryDetail> _repository;

        public RemoveCategoryDetailCommandHandler(IRepository<CategoryDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
