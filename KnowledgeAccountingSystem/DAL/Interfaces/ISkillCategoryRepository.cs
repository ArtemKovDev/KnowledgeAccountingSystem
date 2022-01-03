using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISkillCategoryRepository
    {
        IQueryable<SkillCategory> FindAll();

        Task<SkillCategory> GetByIdAsync(int id);

        Task AddAsync(SkillCategory entity);

        void Update(SkillCategory entity);

        void Delete(SkillCategory entity);

        Task DeleteByIdAsync(int id);

        IQueryable<SkillCategory> GetAllWithDetails();

        Task<SkillCategory> GetByIdWithDetailsAsync(int id);
    }
}
