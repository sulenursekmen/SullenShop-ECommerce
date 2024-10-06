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
    public class UpdateProductCommandHandler
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductCommand updateProductCommand)
        {
            var value = await _repository.GetByIdAsync(updateProductCommand.ProductId);
            value.ProductName = updateProductCommand.ProductName;
            value.CategoryId = updateProductCommand.CategoryId;
            value.CategoryDetailId = updateProductCommand.CategoryDetailId;
            await _repository.UpdateAsync(value);
        }
    }
}
