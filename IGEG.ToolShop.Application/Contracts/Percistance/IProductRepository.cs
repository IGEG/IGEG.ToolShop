using IGEG.ToolShop.Domain.Models;

namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductbyId(int Id);
        Task<IReadOnlyList<Product>> GetProductsByUrlASync(string url);
        Task<IReadOnlyList<Product>> GetAllProductsWithModel();
    }
}
