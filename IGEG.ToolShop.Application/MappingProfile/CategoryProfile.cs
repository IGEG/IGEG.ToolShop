using AutoMapper;
using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Features.Category.Commands.CreateCategory;
using IGEG.ToolShop.Application.Features.Category.Commands.UpdateCategory;
using IGEG.ToolShop.Domain.Models;

namespace IGEG.ToolShop.Application.MappingProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
