using IUNRWA_DTOs.IllnessDto;
using IUNRWA_DTOs.PreviewDto;
using IUNRWA_DTOs.PreviewIllnessDto;
using IUNRWA_Model.Entity;
using IUNRWA_Service.IllnessService;
using IUNRWA_Service.PreviewService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IllnessesController : ControllerBase
    {
        private readonly IIllnessService service;

        public IllnessesController(IIllnessService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddIlllnessType(string name)
        {
            await service.AddIllnessType(name);
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddIlllness(IllnessFormDto formDto)
        {
            var result = await service.AddIllness(formDto);
            return Ok(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPreviewIlllness(PreviewIllnessFormDto formDto)
        {
            var result = await service.AddPreviewIllness(formDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllIlllnessType()
        {
            var result = await service.GetAllIllnessType();
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllIlllness(int? typeId = 0)
        {
            var result = await service.GetAllIllness(typeId);
            return Ok(result);
        }
    }
   

}
