using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SkillCategoryService
        : ISkillCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(SkillCategoryModel model)
        {
            if (model.Name == "")
            {
                throw new KASException();
            }
            var skillCategory = _mapper.Map<SkillCategoryModel, SkillCategory>(model);
            await _unitOfWork.SkillCategoryRepository.AddAsync(skillCategory);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.SkillCategoryRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<SkillCategoryModel> GetAll()
        {
            var skillCategories = _unitOfWork.SkillCategoryRepository.GetAllWithDetails();
            foreach (var s in skillCategories)
            {
                yield return _mapper.Map<SkillCategory, SkillCategoryModel>(s);
            }
        }

        public async Task<SkillCategoryModel> GetByIdAsync(int id)
        {
            var skillCategory = await _unitOfWork.SkillCategoryRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<SkillCategory, SkillCategoryModel>(skillCategory);
        }

        public async Task UpdateAsync(SkillCategoryModel model)
        {
            if (model.Name == "")
            {
                throw new KASException();
            }

            var skillCategory = _mapper.Map<SkillCategoryModel, SkillCategory>(model);
            _unitOfWork.SkillCategoryRepository.Update(skillCategory);
            await _unitOfWork.SaveAsync();
        }
    }
}
