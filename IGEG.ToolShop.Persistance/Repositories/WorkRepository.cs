using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Domain.Models;
using IGEG.ToolShop.Persistance.DataContext;
using IGEG.ToolShop.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;


namespace IGEG.ToolShop.Persistance.Repositories
{
    public class WorkRepository : BaseRepository<Work>, IWorkRepository
    {
        public WorkRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Work>> GetAllWork()
        {
            return await _context.Works.ToListAsync();
        }
    }
}
