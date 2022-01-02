using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserSkillRepository 
    {
        IQueryable<UserSkill> FindAll();

        Task<UserSkill> GetByIdAsync(int id);

        Task AddAsync(UserSkill entity);

        void Update(UserSkill entity);

        void Delete(UserSkill entity);

        Task DeleteByIdAsync(int id);
        IQueryable<UserSkill> GetAllWithDetails();
    }
}
