
using IUNRWA_DTOs.AreaPlaceDto;
using IUNRWA_Service.AreaPlaceService;
using IUNRWA_Service.TeamService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaPlaceController : ControllerBase
    {
        private readonly IAreaPlaceService service;

        public AreaPlaceController(IAreaPlaceService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int areaId)
        {
            var result = await service.GetAllAreaPlace(areaId);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAreaPlace(AreaPlaceFormDto formDto)
        {
            await service.AddAreaPlace(formDto);
            return Ok();
        }

    }
}
