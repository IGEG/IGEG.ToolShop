using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Domain.Models;
using Moq;

namespace IGEG.ToolShop.Application.UnitTests.Mocks
{
    public class MockProductRepository
    {
        public static Mock<IProductRepository> GetMockProductRepository()
        {
            var products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Name1",
                    SmallDescription = "SmallDescription1",
                    BigDescription = "BigDescription1",
                    Images = "Images1",
                    URL = "URL1",
                    Volume = 1,
                    CategoryId = 1
                },
                 new Product
                 {
                    Id = 2,
                    Name = "Name2",
                    SmallDescription = "SmallDescription2",
                    BigDescription = "BigDescription2",
                    Images = "Images2",
                    URL = "URL2",
                    Volume = 2,
                    CategoryId = 2
                 },
                 new Product
                 {
                    Id = 3,
                    Name = "Name3",
                    SmallDescription = "SmallDescription3",
                    BigDescription = "BigDescription3",
                    Images = "Images3",
                    URL = "URL3",
                    Volume = 3,
                    CategoryId = 3
                },
            };

            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(products);

            mockRepo.Setup(x => x.CreateAsync(It.IsAny<Product>())).
                Returns((Product product) => 
                {
                    products.Add(product);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
