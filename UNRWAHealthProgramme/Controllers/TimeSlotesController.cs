using IUNRWA_DTOs.AreaPlaceDto;
using IUNRWA_DTOs.TimeSloteDto;
using IUNRWA_Service.TheServiceService;
using IUNRWA_Service.TimeSloteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotesController : ControllerBase
    {
        private readonly ITimeSloteServices service;

        public TimeSlotesController(ITimeSloteServices service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddTimeSlote(TimeSloteFormDto formDto)
        {
            var result = await service.AddTimeSlote(formDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTimeSlote()
        {
            var result = await service.GetAllTimeSlote();
            return Ok(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetAvailableTimeSlote(AvailableTimeSloteFormDto formDto)
        {
            var result = await service.GetAvilableTimeSlote(formDto);
            return Ok(result);
        }
    }
}
