using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Services.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<DataBaseRequest<IEnumerable<T>>> GetAllAsync(bool ignoreSoftDelete = false, params Expression<Func<T, object>>[] includes);
        Task<DataBaseRequest<IEnumerable<T>>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool ignoreSoftDelete = false, params Expression<Func<T, object>>[] includes);
        Task<DataBaseRequest<T>> GetByIdAsync(int id, bool ignoreSoftDelete = false, params Expression<Func<T, object>>[] includes);
        Task<DataBaseRequest> CreateAsync(T entity);
        Task<DataBaseRequest> UpdateAsync(int id, T entity);
        Task<DataBaseRequest> DeleteAsync(int id);
    }
}
