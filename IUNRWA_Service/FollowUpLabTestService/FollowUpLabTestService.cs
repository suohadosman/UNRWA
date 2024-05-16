using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.PreviewLabTestDto;
using IUNRWA_Model.Entity;
using IUNRWA_Model.UNRWAUsers;
using IUNRWA_Repository;
using IUNRWA_Repository.Repository.UserRepository;
using IUNRWA_ShareKernal.Enum;
using IUNRWA_ShareKernal.Enum.LabTest;
using IUNRWA_ShareKernal.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCDNurse = IUNRWA_Model.UNRWAUsers.NCDNurse;

namespace IUNRWA_Service.FollowUpLabTestService
{
    public class FollowUpLabTestService:IFollowUpLabTestService
    {
        private readonly AppDbContext context;
        private readonly IUserRepository userRepo;
        public FollowUpLabTestService(AppDbContext context, IUserRepository userRepo)
        {
            this.context = context;
            this.userRepo = userRepo;
        }
        #region Action
        public async Task<int> AddFollowUpVisit(int personId)
        {
            var ncdCard = await context.NCDCards.Where(e => e.IsVaild && e.PersonId==personId).FirstOrDefaultAsync();
            NCDNurse ncdNurce = await userRepo.GetCurrentNCDNurse();
            FollwUpVisit visit = new FollwUpVisit
            {
                DateOfVisit = DateTime.UtcNow,
                NCDCard = ncdCard,
                NCDNurse = ncdNurce
            };
            await context.FollwUpVisits.AddAsync(visit);
            await context.SaveChangesAsync();
            return visit.Id;
        }
        public async Task<PreviewLabTestFormDto> AddFollowUpLabTest(PreviewLabTestFormDto formDto)
        {
            var followUp = context.FollwUpVisits.Any(e => e.Id == formDto.FollowUpId && e.IsVaild);
            if (!followUp) { throw new NotFoundException(ErrorMessages.FollowUpNotFound); }
            var labTest = context.LabTests.Any(e => e.Id == formDto.LabTestId && e.IsVaild);
            if (!labTest) { throw new NotFoundException(ErrorMessages.LabTestNotFound); }
            var entity = new IUNRWA_Model.Entity.FollowUpLabTest
            {
                FollwUpVisitId = formDto.FollowUpId,
                LabTestId = formDto.LabTestId,
                Date = formDto.Date,
                Result = null,
                FollowUpLabTestType = formDto.FollowUpLabTestType,
            };
            await context.followUpLabTests.AddAsync(entity);
            await context.SaveChangesAsync();
            formDto.Id = entity.Id;
            return formDto;
        }
        public async Task<LabTestResultFormDto> AddResultToFollowUpLabTest(LabTestResultFormDto formDto)
        {
            var followUpLabTest = await context.followUpLabTests.Where(e => e.Id == formDto.FollowUpLabTestId && e.IsVaild).FirstOrDefaultAsync();
            if (followUpLabTest is null) { throw new NotFoundException(ErrorMessages.FollowUpLabTestNotFound); }
            followUpLabTest.Result = formDto.Result;
            context.followUpLabTests.Update(followUpLabTest);
            await context.SaveChangesAsync();
            return formDto;
        }
        public async Task<LabTestResultFormDto> AddTRResultToFollowLUpLabTest(LabTestResultFormDto formDto)
        {
            var followUpLabTest = await context.followUpLabTests.Where(e => e.Id == formDto.FollowUpLabTestId && e.IsVaild).FirstOrDefaultAsync();
            if (followUpLabTest is null) { throw new NotFoundException(ErrorMessages.FollowUpLabTestNotFound); }
            followUpLabTest.PNResult = formDto.PNResult;
            context.followUpLabTests.Update(followUpLabTest);
            await context.SaveChangesAsync();
            return formDto;
        }
        public async Task MakeFollowUpLabTestDone(int followUpLabTestId)
        {

            var entity = await context.followUpLabTests.Where(e => e.IsVaild && e.Id == followUpLabTestId).FirstOrDefaultAsync();
            entity!.IsDone = true;
            await context.SaveChangesAsync();
        }
        public async Task RequestAnnualLabTests(int followUpVisitId)
        {
            List<int> labTestIds = new List<int> {20,21,22,23,24,25,26,27 };
            var followUp =await context.FollwUpVisits.Where(e => e.Id == followUpVisitId && e.IsVaild).FirstOrDefaultAsync();

            foreach (var item in labTestIds)
            {
                var entity = new IUNRWA_Model.Entity.FollowUpLabTest
                {
                    FollwUpVisitId = followUpVisitId,
                    LabTestId = item,
                    Date = DateTime.UtcNow,
                    Result = null,
                    FollowUpLabTestType = FollowUpLabTestType.Year,
                };
                await context.followUpLabTests.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }
        public async Task RequestMonthlyLabTests(int followUpVisitId)
        {
            List<int> labTestIds = new List<int> { 20, 21, 22, 23, 24, 25, 26, 27 };
            var followUp = await context.FollwUpVisits.Where(e => e.Id == followUpVisitId && e.IsVaild).FirstOrDefaultAsync();

            foreach (var item in labTestIds)
            {
                var entity = new IUNRWA_Model.Entity.FollowUpLabTest
                {
                    FollwUpVisitId = followUpVisitId,
                    LabTestId = item,
                    Date = DateTime.UtcNow,
                    Result = null,
                    FollowUpLabTestType = FollowUpLabTestType.Month,
                };
                await context.followUpLabTests.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        #endregion
        #region Get
        public async Task<List<LabTestResultDto>> GetAllFollowUpLabTestResults(int? personId = 0, int? labTestTypeId = 0)
        {
            var result = await context.followUpLabTests.Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDCard).ThenInclude(e=>e.Person)
                .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
                .Where(e => (e.IsDone) && (e.Result != null)
                && (e.IsVaild)
                && ((personId == 0 && labTestTypeId == 0) ? true :
                (labTestTypeId == 0 ? (e.FollwUpVisit.NCDCard.PersonId== personId) : (e.LabTest.LabTestType.Id == labTestTypeId && (e.FollwUpVisit.NCDCard.PersonId == personId))))
                )
                .Select(e => new LabTestResultDto
                {
                    FollowUpLabTestId = e.Id,
                    LabTestId = e.LabTestId,
                    FollowUpId = e.FollwUpVisitId,
                    PersonId = e.FollwUpVisit.NCDCard.Person.Id,
                    Result = e.Result,
                    Unit = e.LabTest.Unit,
                    LabTestName = e.LabTest.Name,
                    LabTestTypeId = e.LabTest.LabTestType.Id,
                    LabTestTypeName = e.LabTest.LabTestResultType,
                    IsDone = e.IsDone,
                    Date = e.Date,
                    FollowUpLabTestType = e.FollowUpLabTestType
                })
                .ToListAsync();
            return result;
        }
        public async Task<List<LabTestResultDto>> GetAllUNDoneFollowUpLabTest() // to testIncludes
        {
            var result = await context.followUpLabTests.Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDCard).ThenInclude(e => e.Person).Include(e => e.FollwUpVisit.NCDNurse)
                .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
                .Where(e => (!e.IsDone) && (e.IsVaild)).OrderBy(e => e.CreationDate).Select(e => new LabTestResultDto
                {
                    FollowUpLabTestId = e.Id,
                    LabTestId = e.LabTestId,
                    FollowUpId = e.FollwUpVisitId,
                    PersonId = e.FollwUpVisit.NCDCard.Person.Id,
                    Result = e.Result,
                    Unit = e.LabTest.Unit,
                    LabTestName = e.LabTest.Name,
                    LabTestTypeId = e.LabTest.LabTestType.Id,
                    LabTestTypeName = e.LabTest.LabTestResultType,
                    IsDone = e.IsDone,
                    Date = e.Date,
                    FollowUpLabTestType = e.FollowUpLabTestType,
                    PersonName = e.FollwUpVisit.NCDCard.Person.FirstName + " " + e.FollwUpVisit.NCDCard.Person.LastName,
                    DoctorName = e.FollwUpVisit.NCDNurse.Person.FirstName + " " + e.FollwUpVisit.NCDNurse.Person.LastName,
                }).ToListAsync();
            return result;
        }
        public async Task<List<LabTestResultDto>> GetAllDoneFollowUpLabTest()
        {
            var result = await context.followUpLabTests.Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDCard).ThenInclude(e => e.Person).Include(e => e.FollwUpVisit.NCDNurse)
                .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
              .Where(e => (e.IsDone) && (e.IsVaild) && (e.Result == null) && (e.PNResult == null)).OrderBy(e => e.CreationDate).Select(e => new LabTestResultDto
              {
                  FollowUpLabTestId = e.Id,
                  LabTestId = e.LabTestId,
                  FollowUpId = e.FollwUpVisitId,
                  PersonId = e.FollwUpVisit.NCDCard.Person.Id,
                  Result = e.Result,
                  Unit = e.LabTest.Unit,
                  LabTestName = e.LabTest.Name,
                  LabTestTypeId = e.LabTest.LabTestType.Id,
                  LabTestTypeName = e.LabTest.LabTestResultType,
                  IsDone = e.IsDone,
                  Date = e.Date,
                  FollowUpLabTestType = e.FollowUpLabTestType,
                  PersonName = e.FollwUpVisit.NCDCard.Person.FirstName + " " + e.FollwUpVisit.NCDCard.Person.LastName,
                  DoctorName = e.FollwUpVisit.NCDNurse.Person.FirstName + " " + e.FollwUpVisit.NCDNurse.Person.LastName,
              }).ToListAsync();
            return result;
        }
        public async Task<List<NCDAnnualLabTestDto>> GetAllPersonAnnualDoneFollowUpLabTest(int personId)
        {
            var labTestResults = await context.followUpLabTests.Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDCard).ThenInclude(e => e.Person).Include(e => e.FollwUpVisit.NCDNurse)
                .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
              .Where(e => (e.IsDone) &&(e.FollwUpVisit.NCDCard.PersonId == personId) && (e.IsVaild) && ((e.Result != null) || (e.PNResult != null)) && (e.FollowUpLabTestType == FollowUpLabTestType.Year)).OrderBy(e => e.CreationDate).Select(e => new LabTestResultDto
              {
                  FollowUpLabTestId = e.Id,
                  LabTestId = e.LabTestId,
                  FollowUpId = e.FollwUpVisitId,
                  PersonId = e.FollwUpVisit.NCDCard.Person.Id,
                  Result = e.Result,
                  Unit = e.LabTest.Unit,
                  LabTestName = e.LabTest.Name,
                  LabTestTypeId = e.LabTest.LabTestType.Id,
                  LabTestTypeName = e.LabTest.LabTestResultType,
                  IsDone = e.IsDone,
                  Date = e.Date,
                  FollowUpLabTestType = e.FollowUpLabTestType,
                  PersonName = e.FollwUpVisit.NCDCard.Person.FirstName + " " + e.FollwUpVisit.NCDCard.Person.LastName,
                  DoctorName = e.FollwUpVisit.NCDNurse.Person.FirstName + " " + e.FollwUpVisit.NCDNurse.Person.LastName,
              }).ToListAsync();
            var dates = labTestResults.GroupBy(e => e.Date).Select(e=>e.Key).ToList();
            var years = labTestResults.GroupBy(e => e.Date.Year).Select(e => e.Key).ToList();
            List<NCDAnnualLabTestDto> result = new List<NCDAnnualLabTestDto>();
            foreach (var year in years)
            {
                var dtoItem = new NCDAnnualLabTestDto();
                dtoItem.Year = year;
                dtoItem.LabTestResults = labTestResults.Where(e=>e.Date.Year == year).ToList();
                result.Add(dtoItem);
            }
            return result;
        }
        public async Task<List<LabTestResultDto>> GetAllPersonMonthlyDoneFollowUpLabTest(int personId)
        {
            var labTestResults = await context.followUpLabTests.Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDCard).ThenInclude(e => e.Person).Include(e => e.FollwUpVisit.NCDNurse)
                .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
              .Where(e => (e.IsDone) && (e.FollwUpVisit.NCDCard.PersonId == personId) && (e.IsVaild) && ((e.Result != null) || (e.PNResult != null)) && (e.FollowUpLabTestType == FollowUpLabTestType.Month)).OrderBy(e => e.CreationDate).Select(e => new LabTestResultDto
              {
                  FollowUpLabTestId = e.Id,
                  LabTestId = e.LabTestId,
                  FollowUpId = e.FollwUpVisitId,
                  PersonId = e.FollwUpVisit.NCDCard.Person.Id,
                  Result = e.Result,
                  Unit = e.LabTest.Unit,
                  LabTestName = e.LabTest.Name,
                  LabTestTypeId = e.LabTest.LabTestType.Id,
                  LabTestTypeName = e.LabTest.LabTestResultType,
                  IsDone = e.IsDone,
                  Date = e.Date,
                  FollowUpLabTestType = e.FollowUpLabTestType,
                  PersonName = e.FollwUpVisit.NCDCard.Person.FirstName + " " + e.FollwUpVisit.NCDCard.Person.LastName,
                  DoctorName = e.FollwUpVisit.NCDNurse.Person.FirstName + " " + e.FollwUpVisit.NCDNurse.Person.LastName,
              }).ToListAsync();
            return labTestResults;
        }
        public async Task<List<PersonNamesOfLabTestResultsDto>> GetPersonNamesOfFollowUpLabTestResults()
        {
            var entity = await context.followUpLabTests
               .Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDCard).ThenInclude(e => e.Person)
               .Where(e => e.IsVaild && (e.Result != null || e.PNResult != null))
               .ToListAsync();
            var result = entity.GroupBy(e => e.FollwUpVisit.NCDCard.PersonId).Select(e => new PersonNamesOfLabTestResultsDto
            {
                PersonId = e.Key,
                PersonName = e.Where(d => d.FollwUpVisit.NCDCard.PersonId == e.Key).Select(e => e.FollwUpVisit.NCDCard.Person.FirstName).FirstOrDefault()
            }).ToList();
            return result;
        }
        public async Task<List<DatesOfLabTestResultsDto>> GetDatesOfFollowUpLabTestResults(int personId)
        {
            var entity = await context.followUpLabTests
               .Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDCard).ThenInclude(e => e.Person)
               .Where(e => e.IsVaild && (e.Result != null || e.PNResult != null) && e.FollwUpVisit.NCDCard.PersonId == personId)
               .ToListAsync();
            var result = entity.GroupBy(e => e.FollwUpVisit.DateOfVisit.ToShortDateString()).Select(e => new DatesOfLabTestResultsDto
            {
                Date = e.Key,
            }).ToList();

            return result;
        }
        public async Task<List<LabTestResultDto>> GetAllFollowUpLabTestResultsInDate(string date, int? personId = 0)
        {
            var theDate = DateTime.Parse(date);
            var result = await context.followUpLabTests.Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDCard).ThenInclude(e=>e.Person)
                .Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDNurse).ThenInclude(e => e.HealthCenter)
                 .Include(e => e.FollwUpVisit).ThenInclude(e => e.NCDNurse).ThenInclude(e => e.Person)

                .Include(e => e.LabTest).ThenInclude(e => e.LabTestType)
                .Where(e => (e.IsDone)
                && (e.Result != null || e.PNResult != null)
                && (e.IsVaild)
                && (e.Date.Year == theDate.Year) && (e.Date.Month == theDate.Month) && (e.Date.Day == theDate.Day)
                && e.FollwUpVisit.NCDCard.PersonId == personId
                )
                .Select(e => new LabTestResultDto
                {
                    PreviewLabTestId = e.Id,
                    LabTestId = e.LabTestId,
                    FollowUpId = e.FollwUpVisitId,
                    PersonId = e.FollwUpVisit.NCDCard.PersonId,
                    Result = e.Result,
                    Unit = e.LabTest.Unit,
                    LabTestName = e.LabTest.Name,
                    LabTestTypeId = e.LabTest.LabTestType.Id,
                    LabTestTypeName = e.LabTest.LabTestResultType,
                    IsDone = e.IsDone,
                    Date = e.Date,
                    PNResult = e.PNResult,
                    ResultType = e.LabTest.LabTestResultType,
                    HealthCenter = e.FollwUpVisit.NCDNurse.HealthCenter.Name,
                    DoctorName = e.FollwUpVisit.NCDNurse.Person.FirstName + " " + e.FollwUpVisit.NCDNurse.Person.LastName,
                    
                })
                .ToListAsync();
            return result;
        }

        #endregion
    }
}
