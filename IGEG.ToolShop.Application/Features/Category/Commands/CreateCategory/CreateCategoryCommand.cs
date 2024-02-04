using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<int>
    {
        public CategoryDto CategoryDto { get; set; }
    }
}
