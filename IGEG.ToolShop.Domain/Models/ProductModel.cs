using IGEG.ToolShop.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace IGEG.ToolShop.Domain.Models
{
    public class ProductModel : BaseEntity
    {
        [JsonIgnore]
        public Product? Product { get; set; }
        public int ProductOptionId { get; set; }
        public ProductOption? ProductOption { get; set; }

        [Column(TypeName = "Decimal(10,2)")]
        public decimal? Price { get; set; }

        [Column(TypeName = "Decimal(10,2)")]
        public decimal? OldPrice { get; set; }
    }
}
