using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Features.Category.Commands.CreateCategory;
using IGEG.ToolShop.Application.Features.Category.Commands.DeleteCategory;
using IGEG.ToolShop.Application.Features.Category.Commands.UpdateCategory;
using IGEG.ToolShop.Application.Features.Category.Queries.GetAllCategories;
using IGEG.ToolShop.Application.Features.Category.Queries.GetCategoryByUrl;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IGEG.ToolShop.WebAPI.Controllers
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
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            return await _mediator.Send(new GetAllCategoriesQuery());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<ProductController>/category/url
        [HttpGet("category/{Url}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryByUrl(string Url)
        {
            return await _mediator.Send(new GetCategoryByUrlQuery(Url));
        }

        // POST api/<CategoryController>
        [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(CreateCategoryCommand createCommand)
        {
            var response = await _mediator.Send(createCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand() { Id = id });
            return NoContent();
        }
    }
}
