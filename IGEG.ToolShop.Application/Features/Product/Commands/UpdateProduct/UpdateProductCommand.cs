using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.UpdateProduct
{
    public record UpdateProductCommand : IRequest<Unit>
    {
        public ProductDto ProductDto { get; set; }
    }
}
