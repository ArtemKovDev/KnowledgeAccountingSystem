using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class KnowledgeLevelRepository
        : BaseRepository<KnowledgeLevel>, IKnowledgeLevelRepository
    {
        public KnowledgeLevelRepository(ApplicationDbContext context)
            : base(context)
        {

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
