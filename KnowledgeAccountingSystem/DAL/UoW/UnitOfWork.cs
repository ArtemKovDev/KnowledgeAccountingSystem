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
        private PersonSkillRepository personSkillRepository;

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
        public IPersonSkillRepository PersonSkillRepository
        {
            get
            {
                if (personSkillRepository == null)
                    personSkillRepository = new PersonSkillRepository(db);
                return personSkillRepository;
            }
        }

        public Task<int> SaveAsync()
        {
            return db.SaveChangesAsync();
        }
    }
}
