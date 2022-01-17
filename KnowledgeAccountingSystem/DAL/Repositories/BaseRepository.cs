using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    ///<inheritdoc/>
    public abstract class BaseRepository<T>
            : IRepository<T>
            where T : BaseEntity
    {
        private readonly DbSet<T> _set;
        private readonly DbContext _context;
        /// <summary>
        /// Inject DbContext instance
        /// </summary>
        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _set.AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
