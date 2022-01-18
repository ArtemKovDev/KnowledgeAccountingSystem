using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAL
{
    ///<inheritdoc/>
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private SkillRepository skillRepository;
        private UserSkillRepository userSkillRepository;
        private SkillCategoryRepository skillCategoryRepository;
        private KnowledgeLevelRepository knowledgeLevelRepository;
        /// <summary>
        /// Initialize new ApplicationDbContext with injected DbContextOptions
        /// </summary>
        public UnitOfWork(DbContextOptions<ApplicationDbContext> options)
        {
            db = new ApplicationDbContext(options);
        }

        public ISkillRepository SkillRepository
        {
            get
            {
                if (skillRepository == null)
                    skillRepository = new SkillRepository(db);
                return skillRepository;
            }
        }
        public IUserSkillRepository UserSkillRepository
        {
            get
            {
                if (userSkillRepository == null)
                    userSkillRepository = new UserSkillRepository(db);
                return userSkillRepository;
            }
        }
        public ISkillCategoryRepository SkillCategoryRepository
        {
            get
            {
                if (skillCategoryRepository == null)
                    skillCategoryRepository = new SkillCategoryRepository(db);
                return skillCategoryRepository;
            }
        }
        public IKnowledgeLevelRepository KnowledgeLevelRepository
        {
            get
            {
                if (knowledgeLevelRepository == null)
                    knowledgeLevelRepository = new KnowledgeLevelRepository(db);
                return knowledgeLevelRepository;
            }
        }

        public Task<int> SaveAsync()
        {
            return db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
