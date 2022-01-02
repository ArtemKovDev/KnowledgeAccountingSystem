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
    public class SkillRepository
        :ISkillRepository
    {
        private readonly DbSet<Skill> _set;
        private readonly DbContext _context;
        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<Skill>();
        }

        public async Task AddAsync(Skill entity)
        {
            await _set.AddAsync(entity);
        }

        public void Delete(Skill entity)
        {
            _set.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Skill entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public IQueryable<Skill> FindAll()
        {
            return _set.AsQueryable();
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Update(Skill entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<Skill> GetAllWithDetails()
        {
            return FindAll().Include(s => s.Users);
        }

        public async Task<Skill> GetByIdWithDetailsAsync(int id)
        {
            var skills = GetAllWithDetails();
            return await skills.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
