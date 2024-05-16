using IUNRWA_DTOs.ReservationDto;
using IUNRWA_DTOs.TimeSloteDto;
using IUNRWA_Service.ReservationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService service;

        public ReservationsController(IReservationService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNormalReservation(ReservationFormDto formDto)
        {
            await service.AddNormalReservation(formDto);
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddQuickReservation(ReservationFormDto formDto)
        {
            await service.AddQuickReservation(formDto);
            return Ok();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetReservations(int? personId = 0, int? doctorId = 0)
        {
            var result =await service.GetReservations(personId, doctorId);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetDoctorQueueReservations(int doctorId)
        {
            var result = await service.GetDoctorQueueReservations(doctorId);
            return Ok(result);
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> RemoveReservation(int id)
        {
            await service.RemoveReservation(id);
            return Ok();
        }
    }
}
