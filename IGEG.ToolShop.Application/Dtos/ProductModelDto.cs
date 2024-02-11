namespace IGEG.ToolShop.Application.Dtos
{
    public class ProductModelDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ProductDto? Product { get; set; }
        public int ProductOptionId { get; set; }
        public ProductOptionDto? ProductOption { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }
    }
}
