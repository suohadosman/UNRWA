using IUNRWA_DTOs.LabTestDto;
using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.LabTestService
{
    public interface ILabTestService
    {
        public Task<LabTestFormDto> AddLabTest(LabTestFormDto formDto);
        public Task<LabTestFormDto> UpdateLabTest(LabTestFormDto formDto);
        public Task AddLabTestType(string type);
        public Task<List<IUNRWA_DTOs.LabTestDto.LabTestDto>> GetAllLabTest(int? typeId = 0);
        public Task<List<LabTestTypeDto>> GetAllLabTestTypes();
        public Task<List<IUNRWA_DTOs.LabTestDto.LabTestDto>> GetNCDAnnualOrMonthlyLabTest();
        public Task<LabTestFormDto> AddPreviewLabTest(LabTestFormDto formDto);
        public Task MakeLabTestAvailable(int labTestId);
        public Task MakeLabTestUnAvailable(int labTestId);
        public Task RemoveLabTest(int labTestId);
        public Task RemoveAllLabTestTypes();
        public Task RemoveAllLabTests();


    }
}
