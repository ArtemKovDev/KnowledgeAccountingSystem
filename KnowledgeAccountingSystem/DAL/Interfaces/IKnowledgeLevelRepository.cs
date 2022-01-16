using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    /// <summary>
    /// Defines specific CRUD operations for Knowledge Levels data
    /// </summary>
    public interface IKnowledgeLevelRepository : IRepository<KnowledgeLevel>
    {
        /// <summary>
        /// Retrieve all KnowledgeLevel entities with navigation properties
        /// </summary>
        /// <returns>KnowledgeLevel collection</returns>
        IQueryable<KnowledgeLevel> GetAllWithDetails();
        /// <summary>
        /// Retrieve KnowledgeLevel entity by Id
        /// </summary>
        /// <param name="id">KnowledgeLevel Id</param>
        /// <returns>A task that represents the asynchronous GetByIdWithDetailsAsync operation and contains KnowledgeLevel</returns>
        Task<KnowledgeLevel> GetByIdWithDetailsAsync(int id);
    }
}
