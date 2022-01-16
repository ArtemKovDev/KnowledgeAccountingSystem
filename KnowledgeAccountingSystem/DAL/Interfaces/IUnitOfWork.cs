using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    /// <summary>
    /// Defines properties for accessing repositories and method SaveAsync
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Return SkillRepository instance
        /// </summary>
        ISkillRepository SkillRepository { get; }
        /// <summary>
        /// Return UserSkillRepository instance
        /// </summary>
        IUserSkillRepository UserSkillRepository { get; }
        /// <summary>
        /// Return SkillCategoryRepository instance
        /// </summary>
        ISkillCategoryRepository SkillCategoryRepository { get; }
        /// <summary>
        /// Return KnowledgeLevelRepository instance
        /// </summary>
        IKnowledgeLevelRepository KnowledgeLevelRepository { get; }
        /// <summary>
        /// Execute DbContext.SaveChangesAsync()
        /// </summary>
        Task<int> SaveAsync();
    }
}
