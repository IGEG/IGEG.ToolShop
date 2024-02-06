using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.DeleteCategory
{
    public record DeleteCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
