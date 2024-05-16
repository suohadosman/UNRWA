using IUNRWA_DTOs.HealthCenterDto;
using IUNRWA_Service.HealthCenterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCenterController : ControllerBase
    {
        private readonly IHealthCenterService service;

        public HealthCenterController(IHealthCenterService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddHealthCenter(HealthCenterFormDto formDto)
        {
            var result =await service.AddHealthCenter(formDto);
            return Ok(result);
        }

    }
}
