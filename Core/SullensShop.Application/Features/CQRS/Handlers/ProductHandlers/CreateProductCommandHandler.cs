using SullensShop.Application.Features.CQRS.Commands.ProductCommands;
using SullensShop.Application.Interfaces;
using SullensShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand createProductCommand)
        {
            await _repository.CreateAsync(new Product
            {
                ProductName = createProductCommand.ProductName,
                CategoryDetailId = createProductCommand.CategoryDetailId,
                CategoryId = createProductCommand.CategoryId,
            });
        }
    }
}
