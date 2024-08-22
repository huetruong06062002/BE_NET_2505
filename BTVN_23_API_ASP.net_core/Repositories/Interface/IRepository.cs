using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTVN_23_API_ASP.net_core.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
