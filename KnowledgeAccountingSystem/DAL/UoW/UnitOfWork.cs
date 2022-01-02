using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private SkillRepository skillRepository;
        private UserSkillRepository userSkillRepository;

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

        public Task<int> SaveAsync()
        {
            return db.SaveChangesAsync();
        }
    }
}
