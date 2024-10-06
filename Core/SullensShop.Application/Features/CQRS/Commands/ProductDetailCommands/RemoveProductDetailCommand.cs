using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Commands.ProductDetailCommands
{
    public class RemoveProductDetailCommand
    {
        public RemoveProductDetailCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
