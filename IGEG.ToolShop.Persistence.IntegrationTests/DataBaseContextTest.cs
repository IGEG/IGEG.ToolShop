using IGEG.ToolShop.Domain.Models;
using IGEG.ToolShop.Persistance.DataContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace IGEG.ToolShop.Persistence.IntegrationTests
{
    public class DataBaseContextTest
    {
        private readonly DataBaseContext _context;
        public DataBaseContextTest()
        {
            var dbOption = new DbContextOptionsBuilder<DataBaseContext>().
            UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new DataBaseContext(dbOption);
        }
        [Fact]
        public async void Save_SetDateCreatedProduct()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = "Name1",
                SmallDescription = "SmallDescription1",
                BigDescription = "BigDescription1",
                Images = "Images1",
                URL = "URL1",
                Volume = 1,
                CategoryId = 1
            };

            // Act
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            //Assert
            product.DateOfUpdate.ShouldNotBeNull();

        }
    }
}