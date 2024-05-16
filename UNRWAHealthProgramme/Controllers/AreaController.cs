using IUNRWA_DTOs.AreaDto;
using IUNRWA_Service.AreaService;
using IUNRWA_Service.TeamService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService service;

        public AreaController(IAreaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllArea();
            return Ok(result);
        }

       
        [HttpPost]
        public async Task<IActionResult> AddArea(List<string> formDto)
        {
            await service.AddArea(formDto);
            return Ok();
        }

        
    }
}
