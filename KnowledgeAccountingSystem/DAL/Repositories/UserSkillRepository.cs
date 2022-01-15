﻿using DAL.Context;
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
    public class UserSkillRepository
        : BaseRepository<UserSkill>, IUserSkillRepository
    {
        public UserSkillRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<UserSkill> GetAllWithDetails()
        {
            return FindAll().Include(ps => ps.User).Include(ps => ps.Skill).Include(ps => ps.KnowledgeLevel);
        }
    }
}
