using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Domain.Models;
using IGEG.ToolShop.Persistance.DataContext;
using IGEG.ToolShop.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace IGEG.ToolShop.Persistance.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<bool> CheckCategoryUnique(string name)
        {
            return await _context.Categories.AnyAsync(x => x.Name == name);
        }

        public async Task<Category> GetCategoryByUrlAsync(string url)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Url.ToLower().Equals(url.ToLower()));
        }
    }
}
