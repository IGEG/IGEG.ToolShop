using IGEG.ToolShop.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGEG.ToolShop.Domain.Models
{
    public class Product : BaseEntity
    {
        public string? SmallDescription { get; set; }
        public string? BigDescription { get; set; }
        public string? Images { get; set; }
        public string? URL { get; set; }

        [Column(TypeName = "Decimal(10,2)")]
        public decimal? SpesialPrice { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? Volume { get; set; }
        public bool IsOpen { get; set; }
        public bool IsClose { get; set; }
        public DateTime DateOfSaller { get; set; } = DateTime.Now;
        public DateTime? DateOfUpdate { get; set; }

        public List<ProductModel> ProductModels { get; set; } = new List<ProductModel>();
        public int Views { get; set; }
    }
}
