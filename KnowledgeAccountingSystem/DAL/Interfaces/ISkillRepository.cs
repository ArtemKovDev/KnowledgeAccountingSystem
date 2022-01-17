using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    /// <summary>
    /// Defines specific CRUD operations for Skills data
    /// </summary>
    public interface ISkillRepository : IRepository<Skill>
    {
        /// <summary>
        /// Retrieve all Skill entities with navigation properties
        /// </summary>
        /// <returns>Skill collection</returns>
        IQueryable<Skill> GetAllWithDetails();
        /// <summary>
        /// Retrieve Skill entity by Id
        /// </summary>
        /// <param name="id">Skill Id</param>
        /// <returns>A task that represents the asynchronous GetByIdWithDetailsAsync operation and contains Skill</returns>
        Task<Skill> GetByIdWithDetailsAsync(int id);
    }
}
