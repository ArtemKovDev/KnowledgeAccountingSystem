using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving and manipulating Skill Category data 
    /// </summary>
    public interface ISkillCategoryService
    {
        /// <summary>
        /// Retrieves all SkillCategoryModels
        /// </summary>
        /// <returns>SkillCategoryModel collection</returns>
        IEnumerable<SkillCategoryModel> GetAll();
        /// <summary>
        /// Retrieves SkillCategoryModel by Id 
        /// </summary>
        /// <param name="id">SkillCategoryModel Id</param>
        /// <returns>A task that represents the asynchronous GetById operation and contains SkillCategoryModel</returns>
        Task<SkillCategoryModel> GetByIdAsync(int id);
        /// <summary>
        /// Add new SkillCategoryModel 
        /// </summary>
        /// <param name="model">SkillCategoryModel</param>
        /// <returns>A task that represents the asynchronous Add operation.</returns>
        Task AddAsync(SkillCategoryModel model);
        /// <summary>
        /// Update SkillCategoryModel
        /// </summary>
        /// <param name="model">SkillCategoryModel</param>
        /// <returns>A task that represents the asynchronous Update operation.</returns>
        Task UpdateAsync(SkillCategoryModel model);
        /// <summary>
        /// Delete SkillCategoryModel by Id
        /// </summary>
        /// <param name="modelId">SkillCategoryModel Id</param>
        /// <returns>A task that represents the asynchronous DeleteById operation.</returns>
        Task DeleteByIdAsync(int modelId);
    }
}
