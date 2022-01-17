using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    /// <summary>
    /// Defines specific CRUD operations for Skill Categories data
    /// </summary>
    public interface ISkillCategoryRepository : IRepository<SkillCategory>
    {
        /// <summary>
        /// Retrieve all SkillCategory entities with navigation properties
        /// </summary>
        /// <returns>SkillCategory collection</returns>
        IQueryable<SkillCategory> GetAllWithDetails();
        /// <summary>
        /// Retrieve SkillCategory entity by Id
        /// </summary>
        /// <param name="id">SkillCategory Id</param>
        /// <returns>A task that represents the asynchronous GetByIdWithDetailsAsync operation and contains SkillCategory</returns>
        Task<SkillCategory> GetByIdWithDetailsAsync(int id);
    }
}
