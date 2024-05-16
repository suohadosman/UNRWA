using IUNRWA_DTOs.StudyLevelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.StudyLevelService
{
    public interface IStudyLevelService
    {
        public Task AddStudyLevel(List<string> levels);
        public Task<List<StudyLevelDto>> GetAllStudyLevel();
    }
}
