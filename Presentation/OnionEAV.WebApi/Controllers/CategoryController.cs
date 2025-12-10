using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;

namespace OnionEAV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            List<GetCategoryQueryResult> values = await _mediator.Send(new GetCategoryQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            GetCategoryByIdQueryResult value = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            int categoryId = await _mediator.Send(command);
            return Ok(new { Message = "Kategori başarıyla oluşturuldu", CategoryId = categoryId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message = "Kategori başarıyla güncellendi" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return Ok(new { Message = "Kategori başarıyla silindi" });
        }
    }
}
