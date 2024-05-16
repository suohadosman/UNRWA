using IUNRWA_DTOs.PreviewDto;
using IUNRWA_DTOs.PreviewMedicineDto;
using IUNRWA_Service.PreviewMedicineService;
using IUNRWA_Service.PreviewService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewMedicineController : ControllerBase
    {
        private readonly IPreviewMedicineService previewMedicineService;

        public PreviewMedicineController(IPreviewMedicineService previewMedicineService)
        {
            this.previewMedicineService = previewMedicineService;
        }
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddPreviewMedicine(PreviewMedicineFormDto formDto)
        {
            var result = await previewMedicineService.AddPreviewMedicine(formDto);
            return Ok(result);
        }
        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdatePreviewMedicine(PreviewMedicineFormDto formDto)
        {
           await previewMedicineService.UpdatePreviewMedicine(formDto);
            return Ok();
        }
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllPreviewMedicine(int? personId = 0)
        {
            var result = await previewMedicineService.GetAllTakenPreviewMedicine(personId);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllPersonToTakePreviewMedicine()
        {
            var result = await previewMedicineService.GetAllPersonNamesToTakePreviewMedicine();
            return Ok(result);
        }
    }
}
