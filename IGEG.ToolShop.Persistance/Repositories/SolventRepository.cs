using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Domain.Models;
using IGEG.ToolShop.Persistance.DataContext;
using IGEG.ToolShop.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;


namespace IGEG.ToolShop.Persistance.Repositories
{
    public class SolventRepository : BaseRepository<Solvent>, ISolventRepository
    {
        public SolventRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Solvent>> GetAllSolvents()
        {
            return await _context.Solvents.ToListAsync();
        }
    }
}
