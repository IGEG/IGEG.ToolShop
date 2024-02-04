using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Queries.GetProductsByUrl
{
    public record GetProductsByUrlQuery(string productUrl) : IRequest<List<ProductDto>>
    {
    }
}
