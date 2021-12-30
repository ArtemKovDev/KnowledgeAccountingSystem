using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISkillService
    {
        IEnumerable<SkillModel> GetAll();

        Task<SkillModel> GetByIdAsync(int id);

        Task AddAsync(SkillModel model);

        Task UpdateAsync(SkillModel model);

        Task DeleteByIdAsync(int modelId);
    }
}
