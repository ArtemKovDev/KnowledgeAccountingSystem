using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISkillRepository 
    {
        IQueryable<Skill> FindAll();

        Task<Skill> GetByIdAsync(int id);

        Task AddAsync(Skill entity);

        void Update(Skill entity);

        void Delete(Skill entity);

        Task DeleteByIdAsync(int id);

        IQueryable<Skill> GetAllWithDetails();

        Task<Skill> GetByIdWithDetailsAsync(int id);
    }
}
