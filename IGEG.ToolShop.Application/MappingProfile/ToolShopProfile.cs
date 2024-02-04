﻿using AutoMapper;
using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Domain.Entities;

namespace IGEG.ToolShop.Application.MappingProfile
{
    public class ToolShopProfile : Profile
    {
        public ToolShopProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
