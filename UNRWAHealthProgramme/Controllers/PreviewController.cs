using IUNRWA_DTOs.AreaPlaceDto;
using IUNRWA_DTOs.PreviewDto;
using IUNRWA_Model.Entity;
using IUNRWA_Service.PreviewService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly IPreviewService previewService;

        public PreviewController(IPreviewService previewService)
        {
            this.previewService = previewService;
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddPreview(PreviewFormDto formDto)
        {
            var result =await previewService.AddPreview(formDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllPreview(int? personId = 0, int? doctorId = 0)
        {
            var result = await previewService.GetAllPreviews(personId,doctorId);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetPreviewById(int id)
        {
            var result = await previewService.GetPreviewById(id);
            return Ok(result);
        }
    }
}
