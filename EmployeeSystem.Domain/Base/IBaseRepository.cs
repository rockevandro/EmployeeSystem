using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Base
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task Add(T entity);
        Task Update(T entity, long id);
        Task<List<T>> GetAll();
        Task<T> GetById(long id);
    }
}
