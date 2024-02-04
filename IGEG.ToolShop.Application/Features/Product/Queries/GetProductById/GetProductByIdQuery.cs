using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>
    {
    }
}
