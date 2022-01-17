using AutoMapper;
using BLL.Models;
using BLL.Models.Account;
using DAL.Entities;

namespace BLL.Infrastructure
{
    /// <summary>
    /// Provide a named configuration for maps entities to DTO
    /// </summary>
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Skill, SkillModel>()
                .ReverseMap();
            CreateMap<SkillCategory, SkillCategoryModel>()
                .ReverseMap();
            CreateMap<User, UserModel>()
                .ReverseMap();
            CreateMap<KnowledgeLevel, KnowledgeLevelModel>()
                .ReverseMap();
            CreateMap<UserSkill, UserSkillModel>().ReverseMap();
        }
    }
}
