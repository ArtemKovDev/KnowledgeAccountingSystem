using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    /// <summary>
    /// Defines CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">Type that inherited from BaseEntity</typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Retrieve all TEntity objects
        /// </summary>
        /// <returns>TEntity collection</returns>
        IQueryable<TEntity> FindAll();
        /// <summary>
        /// Retrieve TEntity object by Id
        /// </summary>
        /// <param name="id">TEntity Id</param>
        /// <returns>A task that represents the asynchronous GetById operation and contains TEntity</returns>
        Task<TEntity> GetByIdAsync(int id);
        /// <summary>
        /// Add new TEntity
        /// </summary>
        /// <param name="entity">TEntity</param>
        /// <returns>A task that represents the asynchronous Add operation.</returns>
        Task AddAsync(TEntity entity);
        /// <summary>
        /// Update TEntity
        /// </summary>
        /// <param name="entity">TEntity</param>
        void Update(TEntity entity);
        /// <summary>
        /// Delete TEntity
        /// </summary>
        /// <param name="entity">TEntity</param>
        void Delete(TEntity entity);
        /// <summary>
        /// Delete TEntity by Id
        /// </summary>
        /// <param name="id">TEntity Id</param>
        /// <returns>A task that represents the asynchronous DeleteById operation.</returns>
        Task DeleteByIdAsync(int id);
    }
}
