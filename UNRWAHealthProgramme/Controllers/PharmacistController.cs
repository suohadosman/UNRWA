using IUNRWA_DTOs.Views;
using IUNRWA_Repository.Repository.UserRepository;
using IUNRWA_Service.PersonService;
using IUNRWA_Service.PreviewMedicineService;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    public class PharmacistController : Controller
    {
       private readonly IPreviewMedicineService previewMedicineService;
       private readonly IUserRepository userRepository;

        public PharmacistController(IPreviewMedicineService previewMedicineService, IUserRepository userRepository)
        {
            this.previewMedicineService = previewMedicineService;
            this.userRepository = userRepository;
        }
        #region Views
        public async Task<IActionResult> Index()
        {
            var user = await userRepository.GetCurrentPharmascist();
            var dto = new PharmacistViewDto();
            dto.User = user;
            return View(dto);
        }
        public async Task<IActionResult> PharmacyRecords()
        {
            var dto = new PharmacistViewDto();
            dto.AllTakenPreviewMedicines = await previewMedicineService.GetAllTakenPreviewMedicine();
            dto.User = await userRepository.GetCurrentPharmascist();
            return View(dto);
        }
        public async Task<IActionResult> RecipeRecords()
        {
            var dto = new PharmacistViewDto();
            dto.RecipePersonsInfo = await previewMedicineService.GetAllPersonNamesToTakePreviewMedicine();
            dto.UnTakenPreviewMedicines = await previewMedicineService.GetAllUnTakenPreviewMedicine();
            dto.User = await userRepository.GetCurrentPharmascist();
            return View(dto);
        }
        #endregion
        #region Action
        public async Task<IActionResult> TakePreviewMedicines(int personId)
        {
            try
            {
                await previewMedicineService.TakePreviewMedicine(personId);
                TempData["TakeMedicinesSuccess"] = "success";
            }
            catch
            {
                TempData["TakeMedicinesFaild"] = "failed";
            }
            return Redirect("~/Pharmacist/RecipeRecords");
        }
        public async Task<IActionResult> UnTakePreviewMedicine(int previewMedicinId)
        {
            try
            {
                await previewMedicineService.UnTakePreviewMedicine(previewMedicinId);
                TempData["UnTakeMedicinesSuccess"] = "success";
            }
            catch
            {
                TempData["UnTakeMedicinesFaild"] = "failed";
            }
            return Redirect("~/Pharmacist/PharmacyRecords");
        }

        #endregion
    }
}
