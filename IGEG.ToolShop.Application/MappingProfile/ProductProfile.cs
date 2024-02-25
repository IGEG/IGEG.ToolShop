using AutoMapper;
using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct;
using IGEG.ToolShop.Application.Features.Product.Commands.UpdateProduct;
using IGEG.ToolShop.Domain.Models;

namespace IGEG.ToolShop.Application.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

        }
    }
}
