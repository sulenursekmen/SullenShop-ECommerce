using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SullensShop.Application.Features.CQRS.Commands.CategoryDetailCommands;
using SullensShop.Application.Features.CQRS.Handlers.CategoryDetailHandlers;
using SullensShop.Application.Features.CQRS.Queries.CategoryDetailQueries;

namespace SullensShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDetailsController : ControllerBase
    {
        private readonly GetCategoryDetailQueryHandler _getCategoryDetailQueryHandler;
        private readonly GetCategoryDetailByIdQueryHandler _getCategoryDetailByIdQueryHandler;
        private readonly CreateCategoryDetailCommandHandler _createCategoryDetailCommandHandler;
        private readonly UpdateCategoryDetailCommandHandler _updateCategoryDetailCommandHandler;
        private readonly RemoveCategoryDetailCommandHandler _removeCategoryDetailCommandHandler;

        public CategoryDetailsController(GetCategoryDetailQueryHandler getCategoryDetailQueryHandler, GetCategoryDetailByIdQueryHandler getCategoryDetailByIdQueryHandler, CreateCategoryDetailCommandHandler createCategoryDetailCommandHandler, UpdateCategoryDetailCommandHandler updateCategoryDetailCommandHandler, RemoveCategoryDetailCommandHandler removeCategoryDetailCommandHandler)
        {
            _getCategoryDetailQueryHandler = getCategoryDetailQueryHandler;
            _getCategoryDetailByIdQueryHandler = getCategoryDetailByIdQueryHandler;
            _createCategoryDetailCommandHandler = createCategoryDetailCommandHandler;
            _updateCategoryDetailCommandHandler = updateCategoryDetailCommandHandler;
            _removeCategoryDetailCommandHandler = removeCategoryDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryDetailList()
        {
            var values = await _getCategoryDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryDetailById(int id)
        {
            var values = await _getCategoryDetailByIdQueryHandler.Handle(new GetCategoryDetailByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryDetail(CreateCategoryDetailCommand command)
        {
            await _createCategoryDetailCommandHandler.Handle(command);
            return Ok("The CategoryDetail has been created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryDetail(UpdateCategoryDetailCommand command)
        {
            await _updateCategoryDetailCommandHandler.Handle(command);
            return Ok("The CategoryDetail has been updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryDetail(int id)
        {
            await _removeCategoryDetailCommandHandler.Handle(new RemoveCategoryDetailCommand(id));
            return Ok("The CategoryDetail has been deleted successfully");
        }
    }
}
