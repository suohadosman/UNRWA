using IUNRWA_DTOs.DoctorDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService service;

        public DoctorsController(IDoctorService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var result = await service.GetAllDoctor();
            return Ok(result);
        }
    }
}
