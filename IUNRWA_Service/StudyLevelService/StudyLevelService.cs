using IUNRWA_DTOs.RelationshipDto;
using IUNRWA_DTOs.StudyLevelDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.StudyLevelService
{
    public class StudyLevelService : IStudyLevelService
    {
        private readonly IBaseRepository<StudyLevel> studylevelRepo;

        public StudyLevelService(IBaseRepository<StudyLevel> studylevelRepo)
        {
            this.studylevelRepo = studylevelRepo;
        }

        public async Task AddStudyLevel(List<string> levels)
        {
            await studylevelRepo.AddRange(levels.Select(e => new StudyLevel { Level = e }).ToList());
        }

        public async Task<List<StudyLevelDto>> GetAllStudyLevel()
        {
            var areas = await studylevelRepo.GetAll();
            return areas.Select(e => new StudyLevelDto { Id = e.Id, Level = e.Level }).ToList();

        }
    }
}
