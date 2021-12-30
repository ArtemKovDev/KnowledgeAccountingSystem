using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPersonSkillRepository 
    {
        IQueryable<PersonSkill> FindAll();

        Task<PersonSkill> GetByIdAsync(int id);

        Task AddAsync(PersonSkill entity);

        void Update(PersonSkill entity);

        void Delete(PersonSkill entity);

        Task DeleteByIdAsync(int id);
        IQueryable<PersonSkill> GetAllWithDetails();
    }
}
