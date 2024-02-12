using IGEG.ToolShop.Domain.Models;

namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface INewsRepository : IRepository<News>
    {
        Task<IReadOnlyList<News>> GetNews();
        Task<News> GetNewsByURL(string Url);
    }
}
