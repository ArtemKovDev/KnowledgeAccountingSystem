using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using BLL.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(SkillModel model)
        {
            if (model.Name == "" || model.Description == "")
            {
                throw new KASException();
            }
            var skill = _mapper.Map<SkillModel, Skill>(model);
            await _unitOfWork.SkillRepository.AddAsync(skill);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.SkillRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<SkillModel> GetAll()
        {
            var skills = _unitOfWork.SkillRepository.GetAllWithDetails();
            foreach (var s in skills)
            {
                yield return _mapper.Map<Skill, SkillModel>(s);
            }
        }

        public async Task<SkillModel> GetByIdAsync(int id)
        {
            var skill = await _unitOfWork.SkillRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<Skill, SkillModel>(skill);
        }

        public async Task UpdateAsync(SkillModel model)
        {
            if (model.Name == "" || model.Description == "")
            {
                throw new KASException();
            }

            var skill = _mapper.Map<SkillModel, Skill>(model);
            _unitOfWork.SkillRepository.Update(skill);
            await _unitOfWork.SaveAsync();
        }
    }
}
