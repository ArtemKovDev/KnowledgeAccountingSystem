using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    ///<inheritdoc/>
    public class KnowledgeLevelService
        : IKnowledgeLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        /// <summary>
        /// Inject instances of the UnitOfWork and Mapper
        /// </summary>
        public KnowledgeLevelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(KnowledgeLevelModel model)
        {
            if (model.Name == "" || model.Description == "")
            {
                throw new KASException(string.Join(';', "Model is not valid"));
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
            var knowledgeLevels = _unitOfWork.KnowledgeLevelRepository.GetAllWithDetails().ToList();
            return _mapper.Map<List<KnowledgeLevel>, List<KnowledgeLevelModel>>(knowledgeLevels);
        }

        public async Task<KnowledgeLevelModel> GetByIdAsync(int id)
        {
            var knowledgeLevel = await _unitOfWork.KnowledgeLevelRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<KnowledgeLevel, KnowledgeLevelModel>(knowledgeLevel);
        }

        public async Task UpdateAsync(KnowledgeLevelModel model)
        {
            if (model.Id == null || model.Name == "" || model.Description == "")
            {
                throw new KASException(string.Join(';', "Model is not valid"));
            }

            var knowledgeLevel = _mapper.Map<KnowledgeLevelModel, KnowledgeLevel>(model);
            _unitOfWork.KnowledgeLevelRepository.Update(knowledgeLevel);
            await _unitOfWork.SaveAsync();
        }
    }
}
