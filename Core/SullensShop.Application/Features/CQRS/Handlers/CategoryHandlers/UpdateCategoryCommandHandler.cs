using SullensShop.Application.Features.CQRS.Commands.CategoryCommands;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var value = await _repository.GetByIdAsync(updateCategoryCommand.CategoryId);
            value.CategoryId = updateCategoryCommand.CategoryId;
            value.CategoryName = updateCategoryCommand.CategoryName;
            value.ImageUrl = updateCategoryCommand.ImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
