using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.NewFolder;
using IUNRWA_DTOs.PreviewDto;
using IUNRWA_DTOs.PreviewIllnessDto;
using IUNRWA_DTOs.PreviewLabTestDto;
using IUNRWA_DTOs.PreviewMedicineDto;
using IUNRWA_DTOs.ReservationDto;
using IUNRWA_DTOs.Views;
using IUNRWA_Repository.Repository.UserRepository;
using IUNRWA_Service.IllnessService;
using IUNRWA_Service.LabTestService;
using IUNRWA_Service.MedicineService;
using IUNRWA_Service.PersonService;
using IUNRWA_Service.PreviewLabTestService;
using IUNRWA_Service.PreviewMedicineService;
using IUNRWA_Service.PreviewService;
using IUNRWA_Service.ReservationService;
using IUNRWA_Service.TheMeasurementService;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace UNRWAHealthProgramme.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IReservationService reservationService;
        private readonly IMedicineService medicineService;
        private readonly ILabTestService labTestService;
        private readonly IPersonService personService;
        private readonly IPreviewMedicineService previewMedicineService;
        private readonly ITheMeasurementService measurementService;
        private readonly IPreviewService previewService;
        private readonly IIllnessService illnessService;
        private readonly IPreviewLabTestService previewLabTestService;


        public DoctorController(IUserRepository userRepository, IReservationService reservationService, IMedicineService medicineService, ILabTestService labTestService, IPersonService personService, IPreviewMedicineService previewMedicineService, ITheMeasurementService measurementService, IPreviewService previewService, IIllnessService illnessService, IPreviewLabTestService previewLabTestService)
        {
            this.userRepository = userRepository;
            this.reservationService = reservationService;
            this.medicineService = medicineService;
            this.labTestService = labTestService;
            this.personService = personService;
            this.previewMedicineService = previewMedicineService;
            this.measurementService = measurementService;
            this.previewService = previewService;
            this.illnessService = illnessService;
            this.previewLabTestService = previewLabTestService;
        }

        #region View
        public async Task<IActionResult> Index()
        {
            var user = await userRepository.GetCurrentDoctor();
            var doctorReservations = await reservationService.GetDoctorQueueReservations(user.Id);
            DoctorViewDto dto = new();
            dto.User = user;
            dto.DoctorReservations = doctorReservations;
            if (doctorReservations.Count == 0) dto.DoctorReservations.Add(new ReservationDto());
            return View(dto);
        }
        public async Task<IActionResult> Medicines()
        {
            DoctorViewDto dto = new();
            var medicines = await medicineService.GetAllMedicine();
            dto.Medicines = medicines;
            dto.MedicineTypes = await medicineService.GetAllMedicineType();
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
        public async Task<IActionResult> LabTests()
        {
            DoctorViewDto dto = new();
            dto.LabTests = await labTestService.GetAllLabTest();
            dto.LabTestTypes = await labTestService.GetAllLabTestTypes();
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
        public async Task<IActionResult> Queue()
        {
            DoctorViewDto dto = new();
            var user = await userRepository.GetCurrentUser();
            var doctorReservations = await reservationService.GetDoctorQueueReservations(user.Id);
            dto.DoctorReservations = doctorReservations;
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
        public async Task<IActionResult> AllNextReservations()
        {
            DoctorViewDto dto = new();
            var user = await userRepository.GetCurrentUser();
            dto.DoctorReservations = await reservationService.GetAllNextDoctorReservations(0, user.Id);
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
        public async Task<IActionResult> AllPreview()
        {
            DoctorViewDto dto = new();
            var user = await userRepository.GetCurrentUser();
            var doctorReservations = await reservationService.GetAllPreview(0, user.Id);
            dto.DoctorReservations = doctorReservations;
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }

        public async Task<IActionResult> PatientInfo(int personId , int reservationId, int previewId)
        {
            DoctorViewDto dto = new();
            dto.LabTestResults = await previewLabTestService.GetAllLabTestResults(personId,0);
            dto.PersonInfo = await personService.GetById(personId);
            var medicinePreview = await previewMedicineService.GetAllTakenPreviewMedicine(personId);
            dto.LastMedicine = medicinePreview.FirstOrDefault();
            dto.ReservationId = reservationId;
            dto.PreviewId = previewId;
            dto.AllPatientMeasurements = await measurementService.GetAllPersonMeasurements(personId, 0);
            if(previewId == 0)
            {
                var preview = await previewService.AddPreview(new PreviewFormDto { PatientId = personId, ReservationId = reservationId });
                dto.PreviewId = preview.Id;
            }
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
        public async Task<IActionResult> PatientLabTests(int personId, int previewId)
        {
            DoctorViewDto dto = new();
            dto.AllPatientLabTests = await previewLabTestService.GetAllLabTestResults(personId,0);
            dto.PersonInfo = await personService.GetById(personId);
            dto.LabTestTypes = await labTestService.GetAllLabTestTypes();
            dto.PreviewId = previewId;
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
        public async Task<IActionResult> PatientMedicines(int personId, int previewId)
        {
            DoctorViewDto dto = new();
            dto.PersonInfo = await personService.GetById(personId);
            dto.AllPatientMedicine = await previewMedicineService.GetAllPreviewMedicine(personId);
            dto.MedicineTypes = await medicineService.GetAllMedicineType();
            dto.PreviewId = previewId;
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
        public async Task<IActionResult> PatientNCDMedicines(int personId , int previewId)
        {
            DoctorViewDto dto = new();
            dto.PersonInfo = await personService.GetById(personId);
            dto.AllPatientMedicine = await previewMedicineService.GetAllNCDPreviewMedicine(personId);
            dto.MedicineTypes = await medicineService.GetAllMedicineType();
            dto.PreviewId=previewId;
             dto.PersonNCdMedicines= await previewMedicineService.GetAllNCDPreviewMedicine(personId);
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
        public async Task<IActionResult> PatientMesurements(int personId, int previewId)
        {
            DoctorViewDto dto = new();
            dto.PersonInfo = await personService.GetById(personId);
            dto.AllPatientMeasurements = await measurementService.GetAllPersonMeasurements(personId);
            dto.AllMeasurements = await measurementService.GetAllMeasurements();
            dto.PreviewId = previewId;
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
        public async Task<IActionResult> CreatePreview(int personId, int previewId)
        {
            DoctorViewDto dto = new();
            dto.PersonInfo = await personService.GetById(personId);
            dto.PreviewId = previewId;
            var medicines = await medicineService.GetAllMedicine();
            dto.Medicines = medicines.Where(e=>e.Amount >0).ToList();
            dto.MedicineTypes = await medicineService.GetAllMedicineType();
            dto.IllnessTypes = await illnessService.GetAllIllnessType();
            dto.LabTestTypes = await labTestService.GetAllLabTestTypes();
            dto.AllMeasurements = await measurementService.GetAllMeasurements();
            dto.User = await userRepository.GetCurrentDoctor();
            return View(dto);
        }
       
        #endregion
        #region Action
        public async Task<IActionResult> RemoveReservation(int reservationId)
        {

            await reservationService.RemoveReservation(reservationId);
            return Redirect("~/Doctor/Queue");

        }
        public async Task<IActionResult> AddPreviewMedicin(int previewId, int previewMedicineId, int medicineAmount)
        {
            var dto = new PreviewMedicineFormDto { Amount = medicineAmount, PreviewId= previewId, MedicineId = previewMedicineId };
            await previewMedicineService.AddPreviewMedicine(dto);
            return Ok();
        }
        public async Task<IActionResult> AddPreviewIllness(int previewId, int previewIllnessId)
        {
            var dto = new PreviewIllnessFormDto {PreviewId = previewId, IllnessId = previewIllnessId };
            var result = await illnessService.AddPreviewIllness(dto);
            return Ok(result);
        }
        public async Task<IActionResult> AddLabTestToPreview(int previewId, int PreviewLabTestId, DateTime labTestDate)
        {
            var dto = new PreviewLabTestFormDto { PreviewId = previewId, LabTestId = PreviewLabTestId,Date = labTestDate };
            var result = await previewLabTestService.AddPreviewLabTest(dto);
            return Ok();
        }
        public async Task<IActionResult> AddMeasurementToPreview(int previewId, int mesurementId)
        {
            var dto = new TheMeasurementFormDto { PreviewId = previewId, MeasurementId = mesurementId };
            var result = await measurementService.AddPreviewMeasurement(dto);
            return Ok();
        }
        public async Task<IActionResult> RequestNcdMedicines(int personId, int previewId, int NcdId)
        {
            try
            {
                PreviewMedicineFormDto medicineFormDto = new PreviewMedicineFormDto();
                medicineFormDto.NCDId = NcdId;
                medicineFormDto.PreviewId = previewId;
                await previewMedicineService.RequestNcdPreviewMedicine(medicineFormDto);
                TempData["success"] = "success";

            }
            catch
            {
                TempData["failed"] = "failed";

            }
            return Redirect("~/Doctor/PatientNCDMedicines?personId="+ personId+ "&previewId=" +previewId);
        }
        #endregion
        #region Ajax
        [HttpGet]
        public async Task<IActionResult> MedicinesInType(int typeId)
        {
           var result = await medicineService.GetAllMedicine(typeId);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> CreatePreviewMedicinesInType(int typeId)
        {
            var result1 = await medicineService.GetAllMedicine(typeId);
            var result2 = result1.Where(e => e.Amount > 0).ToList();
            return Ok(result2);
        }
        public async Task<IActionResult> LabTestInType(int typeId)
        {
            var result = await labTestService.GetAllLabTest(typeId);
            return Ok(result);
        }
        public async Task<IActionResult> CreatePreviewLabTestInType(int typeId)
        {
            var result1 = await labTestService.GetAllLabTest(typeId);
            var result2 = result1.Where(e => e.IsAvaliable).ToList();
            return Ok(result2);
        }
        public async Task<IActionResult> IllnessInInType(int typeId)
        {
            var result = await illnessService.GetAllIllness(typeId);
            return Ok(result);
        }
        public async Task<IActionResult> PatientLabTestInType(int personId, int typeId)
        {
            var result = await previewLabTestService.GetAllLabTestResults(personId, typeId);
            return Ok(result);
        }
        public async Task<IActionResult> PatientMedicinesInType(int personId, int typeId)
        {
            var result = await previewMedicineService.GetAllPreviewMedicine(personId, typeId);
            return Ok(result);
        }
        public async Task<IActionResult> PatientMeasurementResultInMesurementName(int personId, int meId)
        {
            var result = await measurementService.GetAllPersonMeasurements(personId, meId);
            return Ok(result);
        }
      
        #endregion
    }
}
