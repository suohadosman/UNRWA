using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.PreviewLabTestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.PreviewLabTestService
{
    public interface IPreviewLabTestService
    {
        public Task<PreviewLabTestFormDto> AddPreviewLabTest(PreviewLabTestFormDto formDto);
        public Task<LabTestResultFormDto> AddResultToPreviewLabTest(LabTestResultFormDto formDto);
        public Task<List<LabTestResultDto>> GetAllLabTestResults(int? personId = 0, int? labTestTypeId = 0);
        public Task<List<LabTestResultDto>> GetAllUNDoneLabTest(); // to testIncludes
        public Task MakePreviewLabTestDone(int previewLabTestId);
        public Task<List<LabTestResultDto>> GetAllDoneLabTest();
        public Task<List<PersonNamesOfLabTestResultsDto>> GetPersonNamesOfLabTestResults();
        public Task<List<DatesOfLabTestResultsDto>> GetDatesOfLabTestResults(int personId);

        public Task<LabTestResultFormDto> AddTRResultToPreviewLabTest(LabTestResultFormDto formDto);
        public Task<List<LabTestResultDto>> GetAllLabTestResultsInDate(string date, int? personId = 0);

    }
}
