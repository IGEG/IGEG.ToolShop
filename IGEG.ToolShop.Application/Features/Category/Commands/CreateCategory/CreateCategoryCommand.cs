using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
        public string? Url { get; set; }
    }
}
