using IGEG.ToolShop.Domain.Entities;

namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProductsByUrlASync(string url);
    }
}
