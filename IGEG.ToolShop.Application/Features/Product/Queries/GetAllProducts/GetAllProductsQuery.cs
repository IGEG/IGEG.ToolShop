using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Queries.GetAllProducts
{
    public record GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
