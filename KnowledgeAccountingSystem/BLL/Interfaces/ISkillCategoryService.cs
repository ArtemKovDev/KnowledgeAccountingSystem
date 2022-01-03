using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISkillCategoryService
    {
        IEnumerable<SkillCategoryModel> GetAll();

        Task<SkillCategoryModel> GetByIdAsync(int id);

        Task AddAsync(SkillCategoryModel model);

        Task UpdateAsync(SkillCategoryModel model);

        Task DeleteByIdAsync(int modelId);
    }
}
