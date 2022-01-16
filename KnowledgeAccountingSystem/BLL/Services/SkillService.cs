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
using System.Linq;

namespace BLL.Services
{
    ///<inheritdoc/>
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        /// <summary>
        /// Inject instances of the UnitOfWork and Mapper
        /// </summary>
        public SkillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(SkillModel model)
        {
            if (model.Name == "" || model.Description == "" || model.CategoryId == null)
            {
                throw new KASException(string.Join(';', "Model is not valid"));
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
            var skills = _unitOfWork.SkillRepository.GetAllWithDetails().ToList();
                return _mapper.Map<List<Skill>, List<SkillModel>>(skills);
        }

        public async Task<SkillModel> GetByIdAsync(int id)
        {
            var skill = await _unitOfWork.SkillRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<Skill, SkillModel>(skill);
        }

        public async Task UpdateAsync(SkillModel model)
        {
            if (model.Id == null || model.Name == "" || model.Description == "" || model.CategoryId == null)
            {
                throw new KASException(string.Join(';', "Model is not valid"));
            }

            var skill = _mapper.Map<SkillModel, Skill>(model);
            _unitOfWork.SkillRepository.Update(skill);
            await _unitOfWork.SaveAsync();
        }
    }
}
