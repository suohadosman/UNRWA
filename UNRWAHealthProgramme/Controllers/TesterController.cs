using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.Tester;
using IUNRWA_DTOs.Views;
using IUNRWA_Repository.Repository.UserRepository;
using IUNRWA_Service.FollowUpLabTestService;
using IUNRWA_Service.LabTestService;
using IUNRWA_Service.PersonService;
using IUNRWA_Service.PreviewLabTestService;
using IUNRWA_ShareKernal.Enum.LabTest;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    public class TesterController : Controller
    {
        private readonly ILabTestService service;
        private readonly IPreviewLabTestService previewLabTestService;
        private readonly IFollowUpLabTestService followUpTestService;
        private readonly IPersonService personService;
        private readonly IUserRepository userRepository;

        public TesterController(ILabTestService service, IPreviewLabTestService previewLabTestService, IFollowUpLabTestService followUpTestService, IPersonService personService, IUserRepository userRepository)
        {
            this.service = service;
            this.previewLabTestService = previewLabTestService;
            this.followUpTestService = followUpTestService;
            this.personService = personService;
            this.userRepository = userRepository;
        }
        #region Views
        public async Task<IActionResult> Index()
        {
            TesterDto dto = new TesterDto();
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> LabTestManagement()
        {
            TesterDto dto = new TesterDto();
            dto.AllLabTest = await service.GetAllLabTest();
            dto.LabTestTypes = await service.GetAllLabTestTypes();
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> Queue()
        {
            var result = await previewLabTestService.GetAllUNDoneLabTest();
            TesterDto dto = new TesterDto();
            dto.Queue = result;
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> DoneTests()
        {
            var result = await previewLabTestService.GetAllDoneLabTest();
            TesterDto dto = new TesterDto();
            dto.User = await userRepository.GetCurrentTester();
            dto.DoneLabTest = result;
            return View(dto);
        }
        public async Task<IActionResult> DoneFollowUpTests()
        {
            var result = await followUpTestService.GetAllDoneFollowUpLabTest();
            TesterDto dto = new TesterDto();
            dto.DoneLabTest = result;
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> InsertTRResult( int sampleId)
        {
            var dto = new InsertLabTestResultDto
            {
                PreviewLabTestId = sampleId
            };
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> NCDInsertTRResult(int sampleId)
        {
            var dto = new InsertLabTestResultDto
            {
                PreviewLabTestId = sampleId
            };
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> InsertValueResult(int sampleId)
        {
            var dto = new InsertLabTestResultDto
            {
                PreviewLabTestId = sampleId
            };
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> NCDInsertValueResult(int sampleId)
        {
            var dto = new InsertLabTestResultDto
            {
                FollowUpLabTestId = sampleId
            };
            dto.User = await userRepository.GetCurrentTester();

            return View(dto);
        }
        public async Task<IActionResult> NCDQueue()
        {
            var result = await followUpTestService.GetAllUNDoneFollowUpLabTest();
            TesterDto dto = new TesterDto();
            dto.Queue = result;
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> NCDReports()
        {
           
            TesterDto dto = new TesterDto();
            dto.PersonNamesOfLabTestResults = await followUpTestService.GetPersonNamesOfFollowUpLabTestResults();
            foreach (var person in dto.PersonNamesOfLabTestResults)
            {
                person.LabTestsDates = await followUpTestService.GetDatesOfFollowUpLabTestResults(person.PersonId);

            }
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> Reports()
        {
            TesterDto dto = new TesterDto();
            dto.PersonNamesOfLabTestResults = await previewLabTestService.GetPersonNamesOfLabTestResults();
            foreach (var person in dto.PersonNamesOfLabTestResults)
            {
                person.LabTestsDates = await previewLabTestService.GetDatesOfLabTestResults(person.PersonId);

            }
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> NCDDoneTests()
        {

            var result = await followUpTestService.GetAllDoneFollowUpLabTest();
            TesterDto dto = new TesterDto();
            dto.DoneLabTest = result;
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);
        }
        public async Task<IActionResult> PersonLabTestsInDate(int personId, string date)
        {
           
            TesterDto dto = new TesterDto();
            dto.PersonLabTestResultInDate =await  previewLabTestService.GetAllLabTestResultsInDate(date,personId);
            dto.LabTestTypes =await service.GetAllLabTestTypes();
            dto.AllLabTest = await service.GetAllLabTest();
            dto.PersonInfo = await personService.GetById(personId);
            dto.DateOfLabTest = date;
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);

        }
        public async Task<IActionResult> NCDPersonLabTestsInDate(int personId, string date)
        {

            TesterDto dto = new TesterDto();
            dto.PersonLabTestResultInDate = await followUpTestService.GetAllFollowUpLabTestResultsInDate(date, personId);
            dto.LabTestTypes = await service.GetAllLabTestTypes();
            dto.AllLabTest = await service.GetAllLabTest();
            dto.PersonInfo = await personService.GetById(personId);
            dto.DateOfLabTest = date;
            dto.User = await userRepository.GetCurrentTester();
            return View(dto);

        }
        #endregion
        #region Action
        public async Task<IActionResult> MakeLabeTestAvailable(int labTestId)
        {
            try { 
                await service.MakeLabTestAvailable(labTestId);
                TempData["MakeAvailableSuccess"] = "success";
            }
            catch 
            {
                TempData["MakeAvailableFailed"] = "Failed";
            }
            return Redirect("~/Tester/LabTestManagement");

        }
        public async Task<IActionResult> MakeLabeTestUnAvailable(int labTestId)
        {
            try
            {
                await service.MakeLabTestUnAvailable(labTestId);
                TempData["MakeUnAvailableSuccess"] = "success";
            }
            catch
            {
                TempData["MakeUnAvailableFailed"] = "Failed";
            }
            return Redirect("~/Tester/LabTestManagement");

        }
        public async Task<IActionResult> RemoveLabTest(int labTestId)
        {
            try
            {
                await service.RemoveLabTest(labTestId);
                TempData["RemoveLabTestSuccess"] = "success";
            }
            catch
            {
                TempData["RemoveLabTestFailed"] = "Failed";
            }
            return Redirect("~/Tester/LabTestManagement");

        }
        public async Task<IActionResult> MakeLabTestDone(int previewLabTestId)
        {
            try
            {
                await previewLabTestService.MakePreviewLabTestDone(previewLabTestId);
                TempData["MakeLabTestDoneSuccess"] = "success";
            }
            catch
            {
                TempData["MakeLabTestDoneFailed"] = "Failed";
            }
            return Redirect("~/Tester/Queue");

        }
        public async Task<IActionResult> MakeFollowUpLabTestDone(int followUpLabTestId)
        {
            try
            {
                await followUpTestService.MakeFollowUpLabTestDone(followUpLabTestId);
                TempData["MakeLabTestDoneSuccess"] = "success";
            }
            catch
            {
                TempData["MakeLabTestDoneFailed"] = "Failed";
            }
            return Redirect("~/Tester/NCDQueue");

        }
        [HttpPost]
        public async Task<IActionResult> AddLabTest(TesterDto dto)
        {

            dto.LabTestToAdd = new LabTestFormDto
            {
                Name = dto.LabTestName,
                TypeId = dto.LabTestTypeId,
                NormalResultValue = dto.NormalLabTestSingleValue,
                MinNormalResult = dto.MinValue,
                MaxNormalResult = dto.MaxValue,
                Unit = dto.Unit,
                IsAvaliable = dto.IsAvilable,
                PNNormalResult = dto.TrueFalse
            };
            

            try
            {
                await service.AddLabTest(dto.LabTestToAdd);
                TempData["AddLabTestSuccess"] = "success";
            }
            catch(Exception ex) 
            {
                TempData["AddLabTestFailed"] = "Failed";
            }
            return Redirect("~/Tester/LabTestManagement");

        }
        [HttpPost]
        public async Task<IActionResult> ActionTRResult(InsertLabTestResultDto dto)
        {

            LabTestResultFormDto formDto = new LabTestResultFormDto
            {
                PNResult = dto.PNResult,
                PreviewLabTestId = dto.PreviewLabTestId
            };
            try
            {
                await previewLabTestService.AddTRResultToPreviewLabTest(formDto);
                TempData["AddTRResultSuccess"] = "success";
            }
            catch (Exception ex)
            {
                TempData["AddTRResultFailed"] = "Failed";
            }
            return Redirect("~/Tester/DoneTests");

        }
        [HttpPost]
        public async Task<IActionResult> ActionValueResult(InsertLabTestResultDto dto)
        {

            LabTestResultFormDto formDto = new LabTestResultFormDto
            {
                Result = dto.ValueResult,
                PreviewLabTestId = dto.PreviewLabTestId
            };
            try
            {
                await previewLabTestService.AddResultToPreviewLabTest(formDto);
                TempData["AddValueResultSuccess"] = "success";
            }
            catch (Exception ex)
            {
                TempData["AddValueResultFailed"] = "Failed";
            }
            return Redirect("~/Tester/DoneTests");

        }
        public async Task<IActionResult> ActionNCDValueResult(InsertLabTestResultDto dto)
        {

            LabTestResultFormDto formDto = new LabTestResultFormDto
            {
                Result = dto.ValueResult,
                FollowUpLabTestId = dto.FollowUpLabTestId
            };
            try
            {
                await followUpTestService.AddResultToFollowUpLabTest(formDto);
                TempData["AddValueResultSuccess"] = "success";
            }
            catch (Exception ex)
            {
                TempData["AddValueResultFailed"] = "Failed";
            }
            return Redirect("~/Tester/NCDDoneTests");

        }
        #endregion
    }
}
