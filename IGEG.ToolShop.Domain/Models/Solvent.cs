using IGEG.ToolShop.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGEG.ToolShop.Domain.Models
{
    public class Solvent : BaseEntity
    {

        [Column(TypeName = "Decimal(10,2)")]
        public decimal? Price { get; set; }
    }
}
