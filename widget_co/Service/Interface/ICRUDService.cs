using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICRUDService<T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync(T entity);
        Task<T> GetByIdAsync(T id);
        Task<T> DeleteAsync(T id);
        Task<T> UpdateAsync(T entity);
        Task<T> CreateAsync(T entity);
    }
}
