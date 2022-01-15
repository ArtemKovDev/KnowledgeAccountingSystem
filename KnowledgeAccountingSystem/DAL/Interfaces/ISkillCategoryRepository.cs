using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISkillCategoryRepository : IRepository<SkillCategory>
    {
        IQueryable<SkillCategory> GetAllWithDetails();

        Task<SkillCategory> GetByIdWithDetailsAsync(int id);
    }
}
