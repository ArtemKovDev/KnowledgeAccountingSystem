using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving and manipulating Skill data 
    /// </summary>
    public interface ISkillService
    {
        /// <summary>
        /// Retrieves all SkillModels
        /// </summary>
        /// <returns>SkillModel collection</returns>
        IEnumerable<SkillModel> GetAll();
        /// <summary>
        /// Retrieves SkillModel by Id 
        /// </summary>
        /// <param name="id">SkillModel Id</param>
        /// <returns>A task that represents the asynchronous GetById operation and contains SkillModel</returns>
        Task<SkillModel> GetByIdAsync(int id);
        /// <summary>
        /// Add new SkillModel 
        /// </summary>
        /// <param name="model">SkillModel</param>
        /// <returns>A task that represents the asynchronous Add operation.</returns>
        Task AddAsync(SkillModel model);
        /// <summary>
        /// Update SkillModel
        /// </summary>
        /// <param name="model">SkillModel</param>
        /// <returns>A task that represents the asynchronous Update operation.</returns>
        Task UpdateAsync(SkillModel model);
        /// <summary>
        /// Delete SkillModel by Id
        /// </summary>
        /// <param name="modelId">SkillModel Id</param>
        /// <returns>A task that represents the asynchronous DeleteById operation.</returns>
        Task DeleteByIdAsync(int modelId);
    }
}
