using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct;
using IGEG.ToolShop.Application.Features.Product.Commands.DeleteProduct;
using IGEG.ToolShop.Application.Features.Product.Commands.UpdateProduct;
using IGEG.ToolShop.Application.Features.Product.Queries.GetAllProducts;
using IGEG.ToolShop.Application.Features.Product.Queries.GetProductById;
using IGEG.ToolShop.Application.Features.Product.Queries.GetProductsByUrl;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IGEG.ToolShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<List<ProductDto>> Get()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        // GET api/<ProductController>/category/url
        [HttpGet("category/{Url}")]
        public async Task<ActionResult<List<ProductDto>>> GetProductsByUrl(string Url)
        {
            return await _mediator.Send(new GetProductsByUrlQuery(Url));
        }

        // POST api/<ProductController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateProductCommand createCommand)
        {
            var response = await _mediator.Send(createCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateProductCommand updateCommand)
        {
            await _mediator.Send(updateCommand);
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand() { Id = id });
            return NoContent();
        }
    }
}
