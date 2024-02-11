using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Domain.Models;
using IGEG.ToolShop.Persistance.DataContext;
using IGEG.ToolShop.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace IGEG.ToolShop.Persistance.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        public ProductRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Product>> GetProductsByUrlASync(string url)
        {
            return await _context.Products.Where(x => x.URL == url).ToListAsync();
        }
    }
}
