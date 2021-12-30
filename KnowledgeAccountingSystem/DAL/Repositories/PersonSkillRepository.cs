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
    public class PersonSkillRepository
        :IPersonSkillRepository
    {
        private readonly DbSet<PersonSkill> _set;
        private readonly DbContext _context;

        public PersonSkillRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<PersonSkill>();
        }

        public async Task AddAsync(PersonSkill entity)
        {
            await _set.AddAsync(entity);
        }

        public void Delete(PersonSkill entity)
        {
            _set.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            PersonSkill entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public IQueryable<PersonSkill> FindAll()
        {
            return _set.AsQueryable();
        }

        public async Task<PersonSkill> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Update(PersonSkill entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<PersonSkill> GetAllWithDetails()
        {
            return FindAll().Include(ps => ps.Person).Include(ps => ps.Skill);
        }
    }
}
