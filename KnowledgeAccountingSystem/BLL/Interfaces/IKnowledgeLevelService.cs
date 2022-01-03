using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IKnowledgeLevelService
    {
        IEnumerable<KnowledgeLevelModel> GetAll();

        Task<KnowledgeLevelModel> GetByIdAsync(int id);

        Task AddAsync(KnowledgeLevelModel model);

        Task UpdateAsync(KnowledgeLevelModel model);

        Task DeleteByIdAsync(int modelId);
    }
}
