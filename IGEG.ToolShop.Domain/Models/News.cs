
using IGEG.ToolShop.Domain.Common;

namespace IGEG.ToolShop.Domain.Models
{
    public class News : BaseEntity
    {
        public string? Url { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? SmallDescription { get; set; }
        public string? BigDescription { get; set; }
    }
}
