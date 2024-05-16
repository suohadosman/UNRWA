using IUNRWA_Service.TheServiceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheServicesServiceController : ControllerBase
    {
        private readonly ITheServiceService service;

        public TheServicesServiceController(ITheServiceService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddServices(List<string> services)
        {
            await service.AddServices(services);
            return Ok();
        }
    }
}
