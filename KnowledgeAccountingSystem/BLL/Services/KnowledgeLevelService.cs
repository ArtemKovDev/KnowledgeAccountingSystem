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
    public class KnowledgeLevelService
        : IKnowledgeLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KnowledgeLevelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(KnowledgeLevelModel model)
        {
            if (model.Name == "" || model.Description == "")
            {
                throw new KASException();
            }
            var knowledgeLevel = _mapper.Map<KnowledgeLevelModel, KnowledgeLevel>(model);
            await _unitOfWork.KnowledgeLevelRepository.AddAsync(knowledgeLevel);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _unitOfWork.KnowledgeLevelRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<KnowledgeLevelModel> GetAll()
        {
            var knowledgeLevels = _unitOfWork.KnowledgeLevelRepository.GetAllWithDetails();
            foreach (var k in knowledgeLevels)
            {
                yield return _mapper.Map<KnowledgeLevel, KnowledgeLevelModel>(k);
            }
        }

        public async Task<KnowledgeLevelModel> GetByIdAsync(int id)
        {
            var knowledgeLevel = await _unitOfWork.KnowledgeLevelRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<KnowledgeLevel, KnowledgeLevelModel>(knowledgeLevel);
        }

        public async Task UpdateAsync(KnowledgeLevelModel model)
        {
            if (model.Name == "" || model.Description == "")
            {
                throw new KASException();
            }

            var knowledgeLevel = _mapper.Map<KnowledgeLevelModel, KnowledgeLevel>(model);
            _unitOfWork.KnowledgeLevelRepository.Update(knowledgeLevel);
            await _unitOfWork.SaveAsync();
        }
    }
}
