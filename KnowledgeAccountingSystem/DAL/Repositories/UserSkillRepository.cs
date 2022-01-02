using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserSkillRepository
        :IUserSkillRepository
    {
        private readonly DbSet<UserSkill> _set;
        private readonly DbContext _context;

        public UserSkillRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<UserSkill>();
        }

        public async Task AddAsync(UserSkill entity)
        {
            await _set.AddAsync(entity);
        }

        public void Delete(UserSkill entity)
        {
            _set.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            UserSkill entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public IQueryable<UserSkill> FindAll()
        {
            return _set.AsQueryable();
        }

        public async Task<UserSkill> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Update(UserSkill entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<UserSkill> GetAllWithDetails()
        {
            return FindAll().Include(ps => ps.User).Include(ps => ps.Skill);
        }
    }
}
