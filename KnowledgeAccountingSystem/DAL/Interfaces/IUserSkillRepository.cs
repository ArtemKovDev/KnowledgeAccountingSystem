using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
