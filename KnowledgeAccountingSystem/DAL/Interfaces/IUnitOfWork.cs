using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ISkillRepository SkillRepository { get; }

        IUserSkillRepository UserSkillRepository { get; }

        Task<int> SaveAsync();
    }
}
