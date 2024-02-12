using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Domain.Models;
using IGEG.ToolShop.Persistance.DataContext;
using IGEG.ToolShop.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGEG.ToolShop.Persistance.Repositories
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        public NewsRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<News>> GetNews()
        {
            return await _context.NewsMenu.ToListAsync();
        }

        public async Task<News> GetNewsByURL(string Url)
        {
            return await _context.NewsMenu.FirstOrDefaultAsync(n => n.Url == Url);
        }
    }
}
