
using IGEG.ToolShop.Domain.Common;

namespace IGEG.ToolShop.Domain.Models
{
    public class State : BaseEntity
    {
        public int Views { get; set; }
        public DateTime DateOfView { get; set; }
    }
}
