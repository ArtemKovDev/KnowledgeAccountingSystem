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
    public class SkillCategoryRepository 
        : ISkillCategoryRepository
    {
        private readonly DbSet<SkillCategory> _set;
        private readonly DbContext _context;
        public SkillCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<SkillCategory>();
        }

        public async Task AddAsync(SkillCategory entity)
        {
            await _set.AddAsync(entity);
        }

        public void Delete(SkillCategory entity)
        {
            _set.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            SkillCategory entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public IQueryable<SkillCategory> FindAll()
        {
            return _set.AsQueryable();
        }

        public async Task<SkillCategory> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Update(SkillCategory entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<SkillCategory> GetAllWithDetails()
        {
            return FindAll().Include(s => s.Skills);
        }

        public async Task<SkillCategory> GetByIdWithDetailsAsync(int id)
        {
            var skillCategories = GetAllWithDetails();
            return await skillCategories.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
