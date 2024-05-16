using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.PreviewLabTestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.FollowUpLabTestService
{
    public interface IFollowUpLabTestService
    {
        public Task<PreviewLabTestFormDto> AddFollowUpLabTest(PreviewLabTestFormDto formDto);
        public Task<LabTestResultFormDto> AddResultToFollowUpLabTest(LabTestResultFormDto formDto);
        public Task<LabTestResultFormDto> AddTRResultToFollowLUpLabTest(LabTestResultFormDto formDto);
        public Task MakeFollowUpLabTestDone(int followUpLabTestId);
        public Task<List<LabTestResultDto>> GetAllFollowUpLabTestResults(int? personId = 0, int? labTestTypeId = 0);
        public Task<List<LabTestResultDto>> GetAllUNDoneFollowUpLabTest(); // to testIncludes;
        public Task<List<LabTestResultDto>> GetAllDoneFollowUpLabTest();
        public Task<List<PersonNamesOfLabTestResultsDto>> GetPersonNamesOfFollowUpLabTestResults();
        public Task<List<DatesOfLabTestResultsDto>> GetDatesOfFollowUpLabTestResults(int personId);
        public Task<List<LabTestResultDto>> GetAllFollowUpLabTestResultsInDate(string date, int? personId = 0);
        public Task<int> AddFollowUpVisit(int personId);
        public Task RequestAnnualLabTests(int followUpVisitId);
        public Task RequestMonthlyLabTests(int followUpVisitId);
        public Task<List<NCDAnnualLabTestDto>> GetAllPersonAnnualDoneFollowUpLabTest(int personId);
        public Task<List<LabTestResultDto>> GetAllPersonMonthlyDoneFollowUpLabTest(int personId);
    }
}
