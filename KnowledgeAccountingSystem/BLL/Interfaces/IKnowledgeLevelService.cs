using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving and manipulating Knowledge Levels data 
    /// </summary>
    public interface IKnowledgeLevelService
    {
        /// <summary>
        /// Retrieves all KnowledgeLevelModels
        /// </summary>
        /// <returns>KnowledgeLevelModel collection</returns>
        IEnumerable<KnowledgeLevelModel> GetAll();

        /// <summary>
        /// Retrieves KnowledgeLevelModel by Id
        /// </summary>
        /// <param name="id">KnowledgeLevelModel Id</param>
        /// <returns>A task that represents the asynchronous GetById operation and contains KnowledgeLevelModel</returns>
        Task<KnowledgeLevelModel> GetByIdAsync(int id);

        /// <summary>
        /// Add new KnowledgeLevelModel 
        /// </summary>
        /// <param name="model">KnowledgeLevelModel</param>
        /// <returns>A task that represents the asynchronous Add operation.</returns>
        Task AddAsync(KnowledgeLevelModel model);

        /// <summary>
        /// Update KnowledgeLevelModel
        /// </summary>
        /// <param name="model">KnowledgeLevelModel</param>
        /// <returns>A task that represents the asynchronous Update operation.</returns>
        Task UpdateAsync(KnowledgeLevelModel model);

        /// <summary>
        /// Delete KnowledgeLevelModel by Id
        /// </summary>
        /// <param name="modelId">KnowledgeLevelModel Id</param>
        /// <returns>A task that represents the asynchronous DeleteById operation.</returns>
        Task DeleteByIdAsync(int modelId);
    }
}
