
namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<T> CreateAsync(int Id);
        Task<T> UpdateAsync(int Id);
        Task<T> DeleteAsync(int Id);
    }
}
