using EmployeeSystem.Domain.Base;
using EmployeeSystem.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public virtual async Task Update(T entity, long id)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
