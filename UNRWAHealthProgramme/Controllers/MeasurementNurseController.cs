using IUNRWA_DTOs.Views;
using IUNRWA_Repository.Repository.UserRepository;
using IUNRWA_Service.TheMeasurementService;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    public class MeasurementNurseController : Controller
    {
        private ITheMeasurementService theMeasurementService;
        private readonly IUserRepository userRepository;
        public MeasurementNurseController(ITheMeasurementService theMeasurementService, IUserRepository userRepository)
        {
            this.theMeasurementService = theMeasurementService;
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            MeasurementNurseViewDto dto = new MeasurementNurseViewDto();
            dto.User = await userRepository.GetCurrentMeasurementNurse();
            return View(dto);
        }
        public async Task <IActionResult> Queue()
        {
            MeasurementNurseViewDto dto = new MeasurementNurseViewDto();
            dto.Queue = await theMeasurementService.GetMeasurementQueue();
            dto.User = await userRepository.GetCurrentMeasurementNurse();
            return View(dto);
        }
        public async Task<IActionResult> UnDonePersonMeasurement(int PersonId)
        {
            MeasurementNurseViewDto dto = new MeasurementNurseViewDto();
            dto.UnDonePersonMeasurement = await theMeasurementService.GetAllUnDonePersonMeasurements(PersonId);
            dto.User = await userRepository.GetCurrentMeasurementNurse();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> AddMeasurementResult(MeasurementNurseViewDto dto)
        {

            try
            {
               await theMeasurementService.AddMeasurementResult(dto.MeasurementResultID, dto.Result); 
                TempData["success"] = "success";

            }
            catch
            {
                TempData["failed"] = "failed";
            }
            return Redirect("~/MeasurementNurse/UnDonePersonMeasurement?PersonId="+dto.PersonId);

        }

    }
}
