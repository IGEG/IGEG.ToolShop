using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Queries.GetCategoryByUrl
{
    public record GetCategoryByUrlQuery(string url) : IRequest<CategoryDto>
    {
    }
}
