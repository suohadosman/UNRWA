using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.PreviewLabTestDto;
using IUNRWA_DTOs.PreviewMedicineDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using IUNRWA_ShareKernal.Enum;
using IUNRWA_ShareKernal.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.PreviewLabTestService
{
    public class PreviewLabTestService :IPreviewLabTestService
    {
        private readonly AppDbContext context;

        public PreviewLabTestService(AppDbContext context)
        {
            this.context = context;
        }
        #region Action
        public async Task<PreviewLabTestFormDto> AddPreviewLabTest(PreviewLabTestFormDto formDto)
        {
            var preview = context.Previews.Any(e => e.Id == formDto.PreviewId && e.IsVaild);
            if(!preview) { throw new NotFoundException(ErrorMessages.PreviewNotFound); }
            var labTest = context.LabTests.Any(e => e.Id == formDto.LabTestId && e.IsVaild);
            if (!labTest) { throw new NotFoundException(ErrorMessages.LabTestNotFound); }
            var entity = new PreviewLabTest
            {
                PreviewId = formDto.PreviewId,
                LabTestId = formDto.LabTestId,
                Date = formDto.Date,
                Result = null,
            };
            await context.PreviewLabTests.AddAsync(entity);
            await context.SaveChangesAsync();
            formDto.Id = entity.Id;
            return formDto;
        }
        public async Task<LabTestResultFormDto> AddResultToPreviewLabTest(LabTestResultFormDto formDto)
        {
            var previewLabTest = await context.PreviewLabTests.Where(e => e.Id == formDto.PreviewLabTestId && e.IsVaild).SingleOrDefaultAsync();
            if (previewLabTest is null) { throw new NotFoundException(ErrorMessages.PreviewLabTestNotFound); }
            previewLabTest.Result = formDto.Result;
            context.PreviewLabTests.Update(previewLabTest);
            await context.SaveChangesAsync();
            return formDto;
        }
        public async Task<LabTestResultFormDto> AddTRResultToPreviewLabTest(LabTestResultFormDto formDto)
        {
            var previewLabTest = await context.PreviewLabTests.Where(e => e.Id == formDto.PreviewLabTestId && e.IsVaild).SingleOrDefaultAsync();
            if (previewLabTest is null) { throw new NotFoundException(ErrorMessages.PreviewLabTestNotFound); }
            previewLabTest.PNResult = formDto.PNResult;
            context.PreviewLabTests.Update(previewLabTest);
            await context.SaveChangesAsync();
            return formDto;
        }
        public async Task MakePreviewLabTestDone(int previewLabTestId)
        {

            var entity = await context.PreviewLabTests.Where(e => e.IsVaild && e.Id == previewLabTestId).FirstOrDefaultAsync();
            entity!.IsDone = true;
            await context.SaveChangesAsync();
        }

        #endregion
        #region Get
        public async Task<List<LabTestResultDto>> GetAllLabTestResults( int? personId=0, int? labTestTypeId =0)
        {
            var result = await context.PreviewLabTests.Include(e=>e.Preview).ThenInclude(e=>e.Patient)
                .Include(e=>e.LabTest).ThenInclude(e=>e.LabTestType)
                .Where(e => (e.IsDone) && (e.Result != null)
                && (e.IsVaild)
                && ((personId == 0 && labTestTypeId == 0 ) ? true : 
                ( labTestTypeId == 0 ? (e.Preview.Patient.Id == personId) : (e.LabTest.LabTestType.Id == labTestTypeId && e.Preview.Patient.Id == personId)))
                )
                .Select(e=> new LabTestResultDto
                {
                    PreviewLabTestId = e.Id,
                    LabTestId = e.LabTestId,
                    PreviewId = e.PreviewId,
                    PersonId = e.Preview.Patient.Id,
                    Result = e.Result,
                    Unit = e.LabTest.Unit,
                    LabTestName = e.LabTest.Name,
                    LabTestTypeId = e.LabTest.LabTestType.Id,
                    LabTestTypeName = e.LabTest.LabTestResultType,
                    IsDone = e.IsDone,
                    Date = e.Date,
                    LabTestType = e.LabTest.LabTestType.Name,
                    date2 = e.Date.ToShortDateString() +"  "+ e.Date.ToShortTimeString(),
                })
                .ToListAsync();
            var result2 = await context.followUpLabTests.Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDCard).ThenInclude(e=>e.Person)
               .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
               .Where(e => (e.IsDone) && (e.Result != null)
               && (e.IsVaild)
               && ((personId == 0 && labTestTypeId == 0) ? true :
               (labTestTypeId == 0 ? (e.FollwUpVisit.NCDCard.PersonId == personId) : (e.LabTest.LabTestType.Id == labTestTypeId && e.FollwUpVisit.NCDCard.PersonId == personId)))
               )
               .Select(e => new LabTestResultDto
               {
                   PreviewLabTestId = e.Id,
                   LabTestId = e.LabTestId,
                   PreviewId = e.FollwUpVisitId,
                   PersonId = e.FollwUpVisit.NCDCard.PersonId,
                   Result = e.Result,
                   Unit = e.LabTest.Unit,
                   LabTestName = e.LabTest.Name,
                   LabTestTypeId = e.LabTest.LabTestType.Id,
                   LabTestTypeName = e.LabTest.LabTestResultType,
                   IsDone = e.IsDone,
                   Date = e.Date,
                   LabTestType = e.LabTest.LabTestType.Name
               })
               .ToListAsync();
            result.AddRange(result2);
            result.OrderByDescending(e => e.Date).ToList();
            return result;
        }
        public async Task<List<LabTestResultDto>> GetAllUNDoneLabTest() // to testIncludes
        {
            var result = await context.PreviewLabTests.Include(e => e.Preview).ThenInclude(e => e.Patient).Include(e=>e.Preview.Doctor)
                .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
                .Where(e => (!e.IsDone) && (e.IsVaild)).OrderBy(e=>e.CreationDate).Select(e => new LabTestResultDto
                {
                    PreviewLabTestId = e.Id, // important to make it done
                    LabTestId = e.LabTestId,
                    PreviewId = e.PreviewId,
                    PersonId = e.Preview.Patient.Id,
                    Result = e.Result,
                    Unit = e.LabTest.Unit,
                    LabTestName = e.LabTest.Name,
                    LabTestTypeId = e.LabTest.LabTestType.Id,
                    LabTestTypeName = e.LabTest.LabTestResultType,
                    IsDone = e.IsDone,
                    Date = e.Date,
                    PersonName = e.Preview.Patient.FirstName+" "+ e.Preview.Patient.LastName ,
                    DoctorName = e.Preview.Doctor.Person.FirstName +" " + e.Preview.Doctor.Person.LastName,
                }).ToListAsync();
            return result;
        }
        public async Task<List<LabTestResultDto>> GetAllDoneLabTest()
        {
            var result = await context.PreviewLabTests.Include(e => e.Preview).ThenInclude(e => e.Patient).Include(e => e.Preview.Doctor)
              .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
              .Where(e => (e.IsDone) && (e.IsVaild) && (e.Result == null) && (e.PNResult == null)).OrderBy(e => e.CreationDate).Select(e => new LabTestResultDto
              {
                  PreviewLabTestId = e.Id, // important to make it done
                  LabTestId = e.LabTestId,
                  PreviewId = e.PreviewId,
                  PersonId = e.Preview.Patient.Id,
                  Result = e.Result,
                  Unit = e.LabTest.Unit,
                  LabTestName = e.LabTest.Name,
                  LabTestTypeId = e.LabTest.LabTestType.Id,
                  LabTestTypeName = e.LabTest.LabTestResultType,
                  IsDone = e.IsDone,
                  Date = e.Date,
                  PersonName = e.Preview.Patient.FirstName + " " + e.Preview.Patient.LastName,
                  DoctorName = e.Preview.Doctor.Person.FirstName + " " + e.Preview.Doctor.Person.LastName,
                  ResultType = e.LabTest.LabTestResultType
              }).ToListAsync();
            return result;
        }
        public async Task<List<PersonNamesOfLabTestResultsDto>> GetPersonNamesOfLabTestResults()
        {
            var entity = await context.PreviewLabTests
               .Include(e => e.Preview).ThenInclude(e => e.Patient)
               .Where(e => e.IsVaild && (e.Result != null || e.PNResult != null))
               .ToListAsync();
            var result = entity.GroupBy(e => e.Preview.Patient.Id).Select(e => new PersonNamesOfLabTestResultsDto
            {
                PersonId = e.Key,
                PersonName = e.Where(d => d.Preview.Patient.Id == e.Key).Select(e => e.Preview.Patient.FirstName).FirstOrDefault()
            }).ToList();

            return result;
        }
        public async Task<List<DatesOfLabTestResultsDto>> GetDatesOfLabTestResults(int personId)
        {
            var entity = await context.PreviewLabTests
               .Include(e => e.Preview).ThenInclude(e => e.Patient)
               .Where(e => e.IsVaild && (e.Result != null || e.PNResult != null) &&  e.Preview.Patient.Id == personId)
               .ToListAsync();
            var result = entity.GroupBy(e => e.Date.ToShortDateString()).Select(e => new DatesOfLabTestResultsDto
            {
                Date = e.Key,

            }).ToList();

            return result;
        }
        public async Task<List<LabTestResultDto>> GetAllLabTestResultsInDate(string date,int? personId = 0)
        {
            var theDate =DateTime.Parse(date);
            var result = await context.PreviewLabTests.Include(e => e.Preview).ThenInclude(e => e.Patient)
                .Include(e => e.Preview).ThenInclude(e => e.Doctor).ThenInclude(e=>e.HealthCenter)
                 .Include(e => e.Preview).ThenInclude(e => e.Doctor).ThenInclude(e => e.Person)

                .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
                .Where(e => (e.IsDone) 
                && (e.Result != null || e.PNResult != null)
                && (e.IsVaild)
                && (e.Date.Year == theDate.Year) && (e.Date.Month == theDate.Month) && (e.Date.Day == theDate.Day)
                && e.Preview.Patient.Id == personId
                )
                .Select(e => new LabTestResultDto
                {
                    PreviewLabTestId = e.Id,
                    LabTestId = e.LabTestId,
                    PreviewId = e.PreviewId,
                    PersonId = e.Preview.Patient.Id,
                    Result = e.Result,
                    Unit = e.LabTest.Unit,
                    LabTestName = e.LabTest.Name,
                    LabTestTypeId = e.LabTest.LabTestType.Id,
                    LabTestTypeName = e.LabTest.LabTestResultType,
                    IsDone = e.IsDone,
                    Date = e.Date,
                    PNResult = e.PNResult,
                    ResultType = e.LabTest.LabTestResultType,
                    HealthCenter = e.Preview.Doctor.HealthCenter.Name,
                    DoctorName = e.Preview.Doctor.Person.FirstName + " " + e.Preview.Doctor.Person.LastName
                })
                .ToListAsync();
            return result;
        }
        #endregion
    }
}
