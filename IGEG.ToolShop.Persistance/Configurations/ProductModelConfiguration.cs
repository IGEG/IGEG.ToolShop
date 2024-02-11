using IGEG.ToolShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IGEG.ToolShop.Persistance.Configurations
{
    public class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(p => new { p.Id, p.ProductOptionId });
            builder.HasData(
                new ProductModel { Id = 1, ProductOptionId = 1, Price = 400000.00m, OldPrice = 490000.00m },
                new ProductModel { Id = 1, ProductOptionId = 2, Price = 560000.00m, OldPrice = 690000.00m },
                new ProductModel { Id = 1, ProductOptionId = 3, Price = 490000.00m, OldPrice = 570000.00m },
                new ProductModel { Id = 2, ProductOptionId = 4, Price = 15000.00m, OldPrice = 19000.00m });
        }
    }
}
