using IGEG.ToolShop.Domain.Common;

namespace IGEG.ToolShop.Domain.Models
{
    public class Category : BaseEntity
    {
        public string? Description { get; set; }
        public string? Img { get; set; }
        public string? Url { get; set; }
    }
}
