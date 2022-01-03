using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IKnowledgeLevelRepository
    {
        IQueryable<KnowledgeLevel> FindAll();

        Task<KnowledgeLevel> GetByIdAsync(int id);

        Task AddAsync(KnowledgeLevel entity);

        void Update(KnowledgeLevel entity);

        void Delete(KnowledgeLevel entity);

        Task DeleteByIdAsync(int id);

        IQueryable<KnowledgeLevel> GetAllWithDetails();

        Task<KnowledgeLevel> GetByIdWithDetailsAsync(int id);
    }
}
