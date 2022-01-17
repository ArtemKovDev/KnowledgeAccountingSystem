using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SkillCategoryRepository
        : BaseRepository<SkillCategory>, ISkillCategoryRepository
    {
        public SkillCategoryRepository(ApplicationDbContext context)
            : base(context)
        {

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
