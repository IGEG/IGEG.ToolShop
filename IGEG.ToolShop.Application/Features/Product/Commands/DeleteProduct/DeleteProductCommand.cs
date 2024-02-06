using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.DeleteProduct
{
    public record DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
