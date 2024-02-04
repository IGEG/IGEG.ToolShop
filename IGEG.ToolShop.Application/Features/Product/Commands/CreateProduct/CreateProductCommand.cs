using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct
{
    public record CreateProductCommand : IRequest<int>
    {
        public ProductDto productDto { get; set; }
    }
}
