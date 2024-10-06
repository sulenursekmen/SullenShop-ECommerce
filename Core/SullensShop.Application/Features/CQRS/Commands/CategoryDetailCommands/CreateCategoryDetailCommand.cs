using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Application.Features.CQRS.Commands.CategoryDetailCommands
{
    public class CreateCategoryDetailCommand
    {
        public int CategoryId { get; set; }
        public string CategoryDetailName { get; set; }
        public string ImageUrl { get; set; }
    }
}
