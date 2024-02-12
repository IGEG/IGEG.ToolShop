using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Domain.Common;
using IGEG.ToolShop.Persistance.DataContext;
using Microsoft.EntityFrameworkCore;

namespace IGEG.ToolShop.Persistance.Repositories.Common
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataBaseContext _context;

        public BaseRepository(DataBaseContext context) =>
            _context = context;

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _context.Set<T>().AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
