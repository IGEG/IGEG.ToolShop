using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Features.Product.Queries.GetAllProducts;
using IGEG.ToolShop.Application.Logging;
using IGEG.ToolShop.Application.MappingProfile;
using IGEG.ToolShop.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace IGEG.ToolShop.Application.UnitTests.Features.Product.Queries
{
    public class GetAllProductsQueryHandlerTest
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<GetAllProductsQueryHandler>> _logger;

        public GetAllProductsQueryHandlerTest()
        {
            _mockRepo = MockProductRepository.GetMockProductRepository();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<ProductProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<IAppLogger<GetAllProductsQueryHandler>>();
        }

        [Fact]
        public async Task GetAllProductTest()
        {
            var handler = new GetAllProductsQueryHandler(_mapper, _mockRepo.Object, _logger.Object);
            var result = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<ProductDto>>();
            result.ShouldNotBeNull();
            result.Count.ShouldBe(3);
        }
    }
}
