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
    public class KnowledgeLevelRepository
        : IKnowledgeLevelRepository
    {
        private readonly DbSet<KnowledgeLevel> _set;
        private readonly DbContext _context;
        public KnowledgeLevelRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<KnowledgeLevel>();
        }

        public async Task AddAsync(KnowledgeLevel entity)
        {
            await _set.AddAsync(entity);
        }

        public void Delete(KnowledgeLevel entity)
        {
            _set.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            KnowledgeLevel entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public IQueryable<KnowledgeLevel> FindAll()
        {
            return _set.AsQueryable();
        }

        public async Task<KnowledgeLevel> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Update(KnowledgeLevel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<KnowledgeLevel> GetAllWithDetails()
        {
            return FindAll().Include(s => s.UserSkills);
        }

        public async Task<KnowledgeLevel> GetByIdWithDetailsAsync(int id)
        {
            var knowledgeLevels = GetAllWithDetails();
            return await knowledgeLevels.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
