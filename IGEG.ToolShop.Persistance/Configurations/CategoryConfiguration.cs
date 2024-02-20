using IGEG.ToolShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IGEG.ToolShop.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category 
                {   Id = 1,
                    Name = "Дистилляторы",
                    Img = "oi oi-cog",
                    Url = "distillars",
                    Description = "Оборудование для регенерации растворителей"
                },
                new Category
                { 
                    Id = 2,
                    Name = "Пакеты Rec-Bag",
                    Img = "oi oi-droplet",
                    Url = "Rec-Bag",
                    Description = "Термопакеты для сбора отработанного остатка дистилляции"
                });
        }       
    }
}
