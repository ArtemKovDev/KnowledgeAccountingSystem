using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SkillRepository
        : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<Skill> GetAllWithDetails()
        {
            return FindAll().Include(s => s.Users).Include(s => s.Category);
        }

        public async Task<Skill> GetByIdWithDetailsAsync(int id)
        {
            var skills = GetAllWithDetails();
            return await skills.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
