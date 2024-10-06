using SullensShop.Application.Features.CQRS.Commands.CategoryCommands;
using SullensShop.Application.Features.CQRS.Commands.ProductCommands;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCategoryCommand createCategoryCommand)
        {
            await _repository.CreateAsync(new Category
            {
                CategoryName = createCategoryCommand.CategoryName,
            });
        }
    }
}
