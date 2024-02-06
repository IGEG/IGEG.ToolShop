using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.UpdateCategory
{
    public record UpdateCategoryCommand : IRequest<Unit>
    {
        public CategoryDto CategoryDto { get; set; }
    }
}
