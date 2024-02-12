using IGEG.ToolShop.Domain.Models;

namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface IStateRepository : IRepository<State>
    {
        ValueTask<int> GetVisits();
        Task AddVisit();
    }
}
