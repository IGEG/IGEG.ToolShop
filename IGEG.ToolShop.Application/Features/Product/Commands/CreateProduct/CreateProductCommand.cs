using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct
{
    public record CreateProductCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? SmallDescription { get; set; }
        public string? BigDescription { get; set; }
        public string? Images { get; set; }
        public string? URL { get; set; }
        public decimal? SpesialPrice { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public int? Volume { get; set; }
        public bool IsOpen { get; set; }
        public bool IsClose { get; set; }
        public DateTime DateOfSaller { get; set; }
        public DateTime? DateOfUpdate { get; set; }
        public List<ProductModelDto> ProductModels { get; set; } = new List<ProductModelDto>();
        public int Views { get; set; }
    }
}
