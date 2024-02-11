using IGEG.ToolShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IGEG.ToolShop.Persistance.Configurations
{
    public class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.HasData(
                new ProductOption { Id = 1, Name = "Без опций" },
                new ProductOption { Id = 2, Name = "С генератором вакуума" },
                new ProductOption { Id = 3, Name = "С автоматической загрузкой" },
                new ProductOption { Id = 4, Name = "Упаковка 50 шт." });
        }
    }
}
