using DAL.Entities;
using System.Linq;

namespace DAL.Interfaces
{
    /// <summary>
    /// Defines specific CRUD operations for User skills data
    /// </summary>
    public interface IUserSkillRepository : IRepository<UserSkill>
    {
        /// <summary>
        /// Retrieve all User skill entities with navigation properties
        /// </summary>
        /// <returns>UserSkill collection</returns>
        IQueryable<UserSkill> GetAllWithDetails();
    }
}
