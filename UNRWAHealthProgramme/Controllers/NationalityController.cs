using IUNRWA_Service.AreaService;
using IUNRWA_Service.NationalityService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityService service;

        public NationalityController(INationalityService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllNationality();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddNationality(List<string> formDto)
        {
            await service.AddNationalities(formDto);
            return Ok();
        }
    }
}
