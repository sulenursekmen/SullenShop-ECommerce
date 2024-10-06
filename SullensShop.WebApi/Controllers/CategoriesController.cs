using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SullensShop.Application.Features.CQRS.Commands.CategoryCommands;
using SullensShop.Application.Features.CQRS.Handlers.CategoryHandlers;
using SullensShop.Application.Features.CQRS.Queries.CategoryQueries;
using SullensShop.Domain.Entities;
using SullensShop.WebApi.Services.LoggerService;

namespace SullensShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILoggerService<CategoriesController> _logger;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, ILoggerService<CategoriesController> logger)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var values = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {

            await _logger.LogInfo("Kategoriler alınıyor." + command.CategoryName);
            try
            {
                await _createCategoryCommandHandler.Handle(command);
            }
            catch (Exception ex)
            {
                await _logger.LogError("Bir hata oluştu", ex);
                throw;
            }

            return Ok("The Category has been created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            try
            {
                await _updateCategoryCommandHandler.Handle(command);
            }
            catch (Exception ex)
            {
                await _logger.LogError("Bir hata oluştu", ex);
                throw;
            }

            return Ok("The Category has been updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("The Category has been deleted successfully");
        }
    }
}
