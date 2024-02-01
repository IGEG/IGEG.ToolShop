using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<T> CreateAsync(int Id);
        Task<T> UpdateAsync(int Id);
        Task<T> DeleteAsync(int Id);
    }
}
