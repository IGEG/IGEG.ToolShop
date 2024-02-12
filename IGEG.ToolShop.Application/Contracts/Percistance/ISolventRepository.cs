using IGEG.ToolShop.Domain.Models;

namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface ISolventRepository : IRepository<Solvent>
    {
        Task<IReadOnlyList<Solvent>> GetAllSolvents();
    }
}
