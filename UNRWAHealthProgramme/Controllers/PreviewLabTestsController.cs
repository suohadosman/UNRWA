using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.PreviewLabTestDto;
using IUNRWA_DTOs.ReservationDto;
using IUNRWA_Service.PreviewLabTestService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewLabTestsController : ControllerBase
    {
        private readonly IPreviewLabTestService service;

        public PreviewLabTestsController(IPreviewLabTestService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPreviewLabTest(PreviewLabTestFormDto formDto)
        {
            var result = await service.AddPreviewLabTest(formDto);
            return Ok(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddResultToPreviewLabTest(LabTestResultFormDto formDto)
        {
            var result = await service.AddResultToPreviewLabTest(formDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllLabTestResults(int? personId =0, int? labTestTypeId=0)
        {
            var result = await service.GetAllLabTestResults(personId, labTestTypeId);
            return Ok(result);
        }
    }
}
