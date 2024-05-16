using IUNRWA_DTOs.DoctorDto;
using IUNRWA_DTOs.PersonDto;
using IUNRWA_DTOs.ReservationDto;
using IUNRWA_DTOs.TimeSloteDto;
using IUNRWA_DTOs.Views;
using IUNRWA_Repository.Repository.UserRepository;
using IUNRWA_Service.AreaPlaceService;
using IUNRWA_Service.AreaService;
using IUNRWA_Service.AuthenticationService;
using IUNRWA_Service.FamilyCardService;
using IUNRWA_Service.PersonService;
using IUNRWA_Service.RelationshipService;
using IUNRWA_Service.ReservationService;
using IUNRWA_Service.StudyLevelService;
using IUNRWA_Service.TeamService;
using IUNRWA_Service.TheServiceService;
using IUNRWA_Service.TimeSloteService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Authorize]
    #region constructor
    public class ClerickController : Controller
    {
        private readonly IFamilyCardService familyCardService;
        private readonly IPersonService personService;
        private readonly IAreaService areaService;
        private readonly IRelationshipService relationshipService;
        private readonly ITheServiceService theServiceService;
        private readonly ITeamService teamService;
        private readonly IDoctorService doctorService;
        private readonly IStudyLevelService studyLevelService;
        private readonly IReservationService reservationService;
        private readonly ITimeSloteServices timeSloteService;
        private readonly IAuthenticationService authenticationService;
        private IUserRepository userRepo;
        public ClerickController(IFamilyCardService familyCardService, IPersonService personService, IStudyLevelService studyLevelService, IAreaService areaService, IRelationshipService relationshipService, ITheServiceService theServiceService, ITeamService teamService, IDoctorService doctorService, IReservationService reservationService, ITimeSloteServices timeSloteService, IAuthenticationService authenticationService, IUserRepository userRepo)
        {
            this.familyCardService = familyCardService;
            this.personService = personService;
            this.studyLevelService = studyLevelService;
            this.areaService = areaService;
            this.relationshipService = relationshipService;
            this.theServiceService = theServiceService;
            this.teamService = teamService;
            this.doctorService = doctorService;
            this.reservationService = reservationService;
            this.timeSloteService = timeSloteService;
            this.authenticationService = authenticationService;
            this.userRepo = userRepo;
        }
        #endregion
        #region Views
        public async Task<IActionResult> Home()
        {
            ClerickViewsDto dto = new ClerickViewsDto();
            dto.User = await userRepo.GetClerick();
            return View(dto);
        }
        public async Task<IActionResult> Naming(int personId)
        {

            var dto = new ClerickViewsDto();
            dto.studyLevels = await studyLevelService.GetAllStudyLevel();
            dto.Areas = await areaService.GetAllArea();
            dto.Relationships = await relationshipService.GetAllRelationships();
            dto.PersonToUpdateDto = await personService.GetById(personId);
            dto.User = await userRepo.GetClerick();
            return View(dto);
        }
        public async Task<IActionResult> Reservations(int personId)
        {
            var dto = new ClerickViewsDto();
            dto.PersonId = personId;
            dto.PersonInfo = await personService.GetById(personId);
            dto.Services = await theServiceService.GetAllServices();
            dto.Teams = await teamService.GetAllTeams();
            dto.AllPersonReservations = await reservationService.GetReservations(personId,0);
            dto.User = await userRepo.GetClerick();
            return View(dto);
        }
        #endregion

        #region search
        public async Task<IActionResult> SearchByFamilyCard(ClerickViewsDto dto)
        {
            var familyCard = await familyCardService.GetFamilyCard(0, dto.FamilyCard);
            dto.FamilyCardObject = familyCard;
            dto.User = await userRepo.GetClerick();

            return View(nameof(Home), dto);
        }
        [HttpPost]
        public async Task<IActionResult> SearchByPersonId(ClerickViewsDto dto)
        {
            var person = await personService.GetById(dto.PersonId);
            dto.FamilyCardObject.People.Add(person);
            dto.User = await userRepo.GetClerick();
            return View(nameof(Home), dto);
        }
        public async Task<IActionResult> SearchByChildCard(ClerickViewsDto dto)
        {
            var person = await personService.GetByChildCard(dto.ChildCardNumber);
            dto.FamilyCardObject.People.Add(person);
            dto.User = await userRepo.GetClerick();
            return View(nameof(Home), dto);
        }
        public async Task<IActionResult> SearchByNCD(ClerickViewsDto dto)
        {
            var person = await personService.GetByNCD(dto.NCDNumber);
            dto.FamilyCardObject.People.Add(person);
            dto.User = await userRepo.GetClerick();
            return View(nameof(Home), dto);
        }
        #endregion

        #region Action
        [HttpPost]
        public async Task<IActionResult> Naming(ClerickViewsDto dto )
        {
            dto.User = await userRepo.GetClerick();
            try
            {
                await personService.UpdatePerson(dto.PersonToUpdateFormDto);
                TempData["EditIndividualSuccess"] = "success";
            }
            catch
            {
                TempData["EditIndividualFaild"] = "failed";
            }
            return Redirect("~/Clerick/Naming?personId=" + dto.PersonToUpdateFormDto.Id);

        }
        [HttpPost]
        public async Task<IActionResult> AddNormalReservation(ClerickViewsDto dto)
        {
            dto.User = await userRepo.GetClerick();

            try
            {
                dto.ReservationFormDto.TimeSlotId = dto.AjaxAvailableTimeSloteId;
                dto.ReservationFormDto.DoctorId = dto.AjaxDoctorByTeamId;
                dto.ReservationFormDto.Date = dto.AjaxDate;
                await reservationService.AddNormalReservation(dto.ReservationFormDto);
                TempData["SuccessAddNormalReservation"] = "success";
            }
            catch
            {
                TempData["FaildAddNormalReservation"] = "failed";
            }
            return Redirect("~/Clerick/Reservations?personId=" + dto.ReservationFormDto.PersonId);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddQuickReservation(ClerickViewsDto dto)
        {
            dto.User = await userRepo.GetClerick();

            try
            {
                dto.ReservationFormDto.DoctorId = dto.AjaxDoctorByTeamIdQuick;

                await reservationService.AddQuickReservation(dto.ReservationFormDto);
                TempData["SuccessAddQuickAppointmet"] = "success";
            }
            catch 
            {
                TempData["FaildAddQuickAppointmet"] = "failed";
            }
            return Redirect("~/Clerick/Reservations?personId=" + dto.ReservationFormDto.PersonId);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateReservation(ClerickViewsDto dto)
        {
            dto.User = await userRepo.GetClerick();
            dto.ReservationFormDto.TimeSlotId = dto.AjaxAvailableTimeSloteIdEdit;
            dto.ReservationFormDto.DoctorId = dto.AjaxDoctorByTeamIdEdit;
            dto.ReservationFormDto.Date = dto.AjaxDateEdit;
            await reservationService.UpdateNormalReservation(dto.ReservationFormDto);
            return Redirect("~/Clerick/Reservations?personId=" + dto.PersonId);

        }
        [HttpPost]
        public async Task<IActionResult> RemoveReservation(ClerickViewsDto dto)
        {
            dto.User = await userRepo.GetClerick();
            try
            {
                await reservationService.RemoveReservation(dto.ReservationId);
                TempData["SuccessDeleteAppointmet"] = "success";
            }
            catch
            {
                TempData["FaildDeleteAppointmet"] = "failed";
            }
            return Redirect("~/Clerick/Reservations?personId=" + dto.PersonId);

        }
        public async Task<IActionResult> Logout()
        {

            await authenticationService.Logout();
           
            return Redirect("~/Home/Index");

        }
        #endregion

        #region Ajax
        [HttpGet]
        public async Task<IActionResult> GetDoctorsInTeam(int teamId)
        {
            var result = await doctorService.GetAllDoctor(teamId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult>  GetAvaliabelTimeSlote(AvailableTimeSloteFormDto formDto)
        {
            var result = await timeSloteService.GetAvilableTimeSlote(formDto);
            return Ok(result);
        }
        public async Task<IActionResult> RemoveReservation(int id)
        {
            await reservationService.RemoveReservation(id);
            return Ok();
        }

        #endregion
    }
}
