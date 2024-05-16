using IUNRWA_DTOs.NCDDto;
using IUNRWA_DTOs.Views;
using IUNRWA_Repository.Repository.UserRepository;
using IUNRWA_Service.FollowUpLabTestService;
using IUNRWA_Service.LabTestService;
using IUNRWA_Service.LateComplicationSevice;
using IUNRWA_Service.NCDService;
using IUNRWA_Service.ReservationService;
using IUNRWA_Service.TheMeasurementService;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    public class NCDNurseController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IReservationService reservationService;
        private readonly INCDService nCDService;
        private readonly IFollowUpLabTestService followUpServiceService;
        private readonly ILabTestService labTestService;
        private readonly ITheMeasurementService mesurementService;
        private readonly ILateComplicationService lateComplicationService;

        public NCDNurseController(IUserRepository userRepository, IReservationService reservationService, INCDService nCDService, IFollowUpLabTestService followUpServiceService, ILabTestService labTestService, ITheMeasurementService mesurementService, ILateComplicationService lateComplicationService)
        {
            this.userRepository = userRepository;
            this.reservationService = reservationService;
            this.nCDService = nCDService;
            this.followUpServiceService = followUpServiceService;
            this.labTestService = labTestService;
            this.mesurementService = mesurementService;
            this.lateComplicationService = lateComplicationService;
        }

        #region View
        public async Task<IActionResult> Index()
        {
            NCDNurseViewDto dto = new();
            dto.User = await userRepository.GetCurrentNCDNurse();
            return View(dto);
        }
        public async Task<IActionResult> Queue()
        {
            NCDNurseViewDto dto = new();
            var user = await userRepository.GetCurrentUser();
            dto.Reservations = await reservationService.GetDoctorQueueReservations(user.Id);
            dto.User = await userRepository.GetCurrentNCDNurse();
            return View(dto);
        }
        public async Task<IActionResult> CreateNCDCard(int personId)
        {
            NCDNurseViewDto dto = new NCDNurseViewDto();
            NCDFormDto formDto = new NCDFormDto
            {
                personId = personId
            };
            dto.CreatedNCDCardInfo = await nCDService.AddNCDCard(formDto);
            dto.User = await userRepository.GetCurrentNCDNurse();
            return View(dto);
        }
        public async Task<IActionResult> NCDPatientInfo(int personId, int reservationId)
        {
            NCDNurseViewDto dto = new NCDNurseViewDto();
            dto.PersonId = personId;
            dto.FollowUpVisitId = await followUpServiceService.AddFollowUpVisit(personId);
            if (reservationId != 0) await reservationService.MakeReservationDone(reservationId);
            dto.User = await userRepository.GetCurrentNCDNurse();
            return View(dto);
        }
        public async Task<IActionResult> AnnualFolowUpLabTest(int personId, int followUpVisitId)
        {
            NCDNurseViewDto dto = new NCDNurseViewDto();
            dto.PersonId = personId;
            dto.FollowUpVisitId = followUpVisitId;
            dto.PersonAnnualLabTest = await followUpServiceService.GetAllPersonAnnualDoneFollowUpLabTest(personId);
            dto.AllNCDAnnualLabTest = await labTestService.GetNCDAnnualOrMonthlyLabTest(); // I test it
            dto.User = await userRepository.GetCurrentNCDNurse();
            return View(dto);
        }
        public async Task<IActionResult> MonthlyFolowUpLabTest(int personId, int followUpVisitId)
        {
            NCDNurseViewDto dto = new NCDNurseViewDto();
            dto.PersonId = personId;
            dto.FollowUpVisitId = followUpVisitId;
            dto.PersonMonthlyLabTest = await followUpServiceService.GetAllPersonMonthlyDoneFollowUpLabTest(personId);
            dto.AllNCDAnnualLabTest = await labTestService.GetNCDAnnualOrMonthlyLabTest(); // I test it
            dto.User = await userRepository.GetCurrentNCDNurse();
            return View(dto);
        }
        public async Task<IActionResult> PersonMesurements(int personId, int followUpVisitId)
        {
            NCDNurseViewDto dto = new NCDNurseViewDto();
            dto.PersonId = personId;
            dto.PersonMesurements = await mesurementService.GetAllPersonMeasurements(personId);
            dto.FollowUpVisitId = followUpVisitId;
            dto.User = await userRepository.GetCurrentNCDNurse();
            return View(dto);
        }
        public async Task<IActionResult> PersonLateComplication(int personId, int followUpVisitId)
        {
            NCDNurseViewDto dto = new NCDNurseViewDto();
            dto.PersonId = personId;
            dto.FollowUpVisitId = followUpVisitId;
            dto.PersonLateComplications = await lateComplicationService.GetAllPersonLateComplication(personId);
            dto.AllLateComplications = await lateComplicationService.GetAllLateComplications();
            dto.User = await userRepository.GetCurrentNCDNurse();
            return View(dto);
        }

        #endregion
        #region Action
        public async Task<IActionResult> RequestAnnualLabTests(int followUpVisitId, int personId)
        {
            try
            {
                await followUpServiceService.RequestAnnualLabTests(followUpVisitId); 
                TempData["RequestAnnualLabTestsSuccess"] = "success";
            }
            catch
            {
                TempData["RequestAnnualLabTestsFaild"] = "failed";
            }
            return Redirect("~/NCDNurse/AnnualFolowUpLabTest?personId="+personId+ "&followUpVisitId="+followUpVisitId);

        }
        [HttpPost]
        public async Task<IActionResult> AddFollowUpLateComplication(NCDNurseViewDto dto)
        {
            try
            {
                await lateComplicationService.AddFollowUpLateComplication(dto.FollowUpVisitId, dto.LateComplicationId, dto.LateComplicationStatus);
                TempData["success"] = "success";
            }
            catch
            {
                TempData["failed"] = "failed";
            }
            return Redirect("~/NCDNurse/PersonLateComplication?personId=" + dto.PersonId + "&followUpVisitId=" + dto.FollowUpVisitId);

        }

        public async Task<IActionResult> RequestMonthlyLabTests(int followUpVisitId, int personId)
        {
            try
            {
                await followUpServiceService.RequestMonthlyLabTests(followUpVisitId);
                TempData["RequestAnnualLabTestsSuccess"] = "success";
            }
            catch
            {
                TempData["RequestAnnualLabTestsFaild"] = "failed";
            }
            return Redirect("~/NCDNurse/MonthlyFolowUpLabTest?personId=" + personId + "&followUpVisitId=" + followUpVisitId);

        }
        public async Task<IActionResult> RequesNCDMesurements(int followUpVisitId, int personId)
        {
            try
            {
                await mesurementService.RequestNCDMeasurement(personId,followUpVisitId); // I test it
                TempData["RequestMesurementSuccess"] = "success";
            }
            catch
            {
                TempData["RequestMesurementFaild"] = "failed";
            }
            return Redirect("~/NCDNurse/PersonMesurements?personId=" + personId + "&followUpVisitId=" + followUpVisitId);
        }
        #endregion
    }
}
