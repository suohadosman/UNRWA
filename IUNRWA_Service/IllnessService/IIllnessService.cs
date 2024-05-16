using IUNRWA_DTOs.IllnessDto;
using IUNRWA_DTOs.PreviewIllnessDto;
using IUNRWA_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.IllnessService
{
    public interface IIllnessService
    {
        public Task<IllnessFormDto> AddIllness(IllnessFormDto formDto);
        public Task AddIllnessType(string Name);
        public Task<PreviewIllnessFormDto> AddPreviewIllness(PreviewIllnessFormDto formDto);
        public Task<List<IllnessTypDto>> GetAllIllnessType();
        public Task<List<IllnessDto>> GetAllIllness(int? typeId=0);

        public Task<List<IllnessDto>> GetAllPatientIllness(int personId);
        public Task<List<IllnessDto>> GetAllPatientIllnessInType(int personId, int typeId);

    }
}
