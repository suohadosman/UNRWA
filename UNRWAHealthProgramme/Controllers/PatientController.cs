using IUNRWA_DTOs.Views;
using IUNRWA_Model.Entity;
using IUNRWA_Service.FollowUpLabTestService;
using IUNRWA_Service.IllnessService;
using IUNRWA_Service.LabTestService;
using IUNRWA_Service.LateComplicationService;
using IUNRWA_Service.LateComplicationSevice;
using IUNRWA_Service.PersonService;
using IUNRWA_Service.PreviewLabTestService;
using IUNRWA_Service.PreviewMedicineService;
using IUNRWA_Service.ReservationService;
using IUNRWA_Service.TheMeasurementService;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    public class PatientController : Controller

    {
        private readonly IPersonService personService;
        private readonly IReservationService reservationService;
        private readonly ITheMeasurementService measurementService;
        private readonly IPreviewMedicineService previewMedicineService;
        private readonly IPreviewLabTestService previewLabTestService;
        private readonly ILabTestService labTestService;
        private readonly IIllnessService illnessService;
        private readonly IFollowUpLabTestService followUpServiceService;
        private readonly ITheMeasurementService mesurementService;
        private readonly ILateComplicationService lateComplicationService;

        public PatientController(IPersonService personService, IReservationService reservationService, ITheMeasurementService measurementService, IPreviewMedicineService previewMedicineService, IPreviewLabTestService previewLabTestService, ILabTestService labTestService, IIllnessService illnessService, IFollowUpLabTestService followUpServiceService, ITheMeasurementService mesurementService, ILateComplicationService lateComplicationService)
        {
            this.personService = personService;
            this.reservationService = reservationService;
            this.measurementService = measurementService;
            this.previewMedicineService = previewMedicineService;
            this.previewLabTestService = previewLabTestService;
            this.labTestService = labTestService;
            this.illnessService = illnessService;
            this.followUpServiceService = followUpServiceService;
            this.mesurementService = mesurementService;
            this.lateComplicationService = lateComplicationService;
        }

        public IActionResult Welcome()
        {
            PatientViewDto dto = new PatientViewDto();
            return View(dto);
        }
        public async Task<IActionResult> Home(int personId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.PersonInfo = await personService.GetById(personId);
            return View(dto);
        }
        public async Task<IActionResult> SearchById(PatientViewDto dto)
        {
            dto.PersonInfo = await personService.GetById(dto.PersonIdToSearch);
            if (dto.PersonInfo != null)
            {
                return Redirect("~/Patient/Home?personId="+dto.PersonIdToSearch);
            }
            else
            {
                TempData["personNotFound"] = "failed";
                return Redirect("~/Patient/Welcome");

            }
        }
        public async Task<IActionResult> AllNextReservations(int personId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.PersonIdToSearch = personId; 
            dto.AllNextReservations = await reservationService.GetAllNextPersonReservations(personId);
            return View(dto);
        }
        public async Task<IActionResult> AllMeasurements(int personId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.PersonIdToSearch = personId;
            dto.AllMeasurements = await measurementService.GetAllPersonMeasurements(personId);
            return View(dto);
        }
        public async Task<IActionResult> AllPatientMedicines(int personId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.PersonIdToSearch = personId;
            dto.AllMedicines = await previewMedicineService.GetAllPatientMedicines(personId);
            return View(dto);
        }
        public async Task<IActionResult> AllPatientLabTests(int personId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.AllPatientLabTests = await previewLabTestService.GetAllLabTestResults(personId, 0);
            dto.PersonIdToSearch = personId;
            dto.LabTestTypes = await labTestService.GetAllLabTestTypes();
            return View(dto);
        }
        public async Task<IActionResult> AllPatientIllness(int personId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.AllIllness = await illnessService.GetAllPatientIllness(personId);
            dto.PersonIdToSearch = personId;
            dto.illnessTyps = await illnessService.GetAllIllnessType();
            return View(dto);
        }
        public async Task<IActionResult> PatientIllnessInType(int personId, int typeId)
        {
            var result = await illnessService.GetAllPatientIllnessInType(personId, typeId);
            return Ok(result);
        }
        public async Task<IActionResult> NCDPatientInfo(int personId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.PersonIdToSearch = personId;
            return View(dto);
        }
        public async Task<IActionResult> PatientAnnualLabTest(int personId, int typeId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.PersonIdToSearch = personId;
            dto.PersonAnnualLabTest = await followUpServiceService.GetAllPersonAnnualDoneFollowUpLabTest(personId);
            dto.AllNCDAnnualLabTest = await labTestService.GetNCDAnnualOrMonthlyLabTest(); // I test it
            return View(dto);
        }
        public async Task<IActionResult> PatientMonthlyFolowUpLabTest(int personId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.PersonIdToSearch = personId;
            dto.PersonMonthlyLabTest = await followUpServiceService.GetAllPersonMonthlyDoneFollowUpLabTest(personId);
            dto.AllNCDAnnualLabTest = await labTestService.GetNCDAnnualOrMonthlyLabTest(); // I test it
            return View(dto);

        }
        public async Task<IActionResult> PatientMesurements(int personId)
        {
            PatientViewDto dto = new PatientViewDto();
            dto.PersonIdToSearch = personId;
            dto.PersonMesurements = await mesurementService.GetAllPersonMeasurements(personId);
            return View(dto);
        }
        public async Task<IActionResult> PatientLateComplication(int personId)
        {

            PatientViewDto dto = new PatientViewDto();
            dto.PersonIdToSearch = personId;
            dto.PersonLateComplications = await lateComplicationService.GetAllPersonLateComplication(personId);
            dto.AllLateComplications = await lateComplicationService.GetAllLateComplications();
            return View(dto);
        }
    }
}
