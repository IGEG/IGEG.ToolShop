using IGEG.ToolShop.Domain.Models;

namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface IWorkRepository : IRepository<Work>
    {
        Task<IReadOnlyList<Work>> GetAllWork();
    }
}
