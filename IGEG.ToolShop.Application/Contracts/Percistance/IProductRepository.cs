using IGEG.ToolShop.Domain.Models;

namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IReadOnlyList<Product>> GetProductsByUrlASync(string url);
    }
}
