using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Domain.Models;
using IGEG.ToolShop.Persistance.DataContext;
using IGEG.ToolShop.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace IGEG.ToolShop.Persistance.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductRepository(DataBaseContext context, ICategoryRepository categoryRepository) : base(context)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IReadOnlyList<Product>> GetAllProductsWithModel()
        {
            return await _context.Products.Include(x => x.ProductModels).ToListAsync();
        }

        public async Task<Product> GetProductbyId(int Id)
        {

            var product = await _context.Products.Include(o => o.ProductModels)
                .ThenInclude(p => p.ProductOption).FirstOrDefaultAsync(p => p.Id == Id);

            if (product != null)
                product.Views++;

            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsByUrlASync(string url)
        {
            var category = await _categoryRepository.GetCategoryByUrlAsync(url);

            return await _context.Products.Include(m => m.ProductModels)
                .Where(p => p.CategoryId == category.Id).ToListAsync();
        }
    }
}
