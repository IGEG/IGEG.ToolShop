using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Domain.Models;
using IGEG.ToolShop.Persistance.DataContext;
using IGEG.ToolShop.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;


namespace IGEG.ToolShop.Persistance.Repositories
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task AddVisit()
        {
            var visit = await _context.States.FirstOrDefaultAsync();
            if (visit == null)
            {
                await _context.States.AddAsync(new State { Views = 1, DateOfView = DateTime.Now }); ;
            }
            else
            {
                visit.Views++;
                visit.DateOfView = DateTime.Now;
            }
            await _context.SaveChangesAsync();
        }

        public async ValueTask<int> GetVisits()
        {
            var visit = await _context.States.FirstOrDefaultAsync();
            if (visit == null)
            {
                return 0;
            }
            return visit.Views;
        }
    }
}
