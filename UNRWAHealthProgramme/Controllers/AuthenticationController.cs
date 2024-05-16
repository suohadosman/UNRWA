using IUNRWA_DTOs.AuthenticationDto;
using IUNRWA_Service.AuthenticationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService service;

        public AuthenticationController(IAuthenticationService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUpEmployee(SignUpEmployeeFormDto formDto)
        {
            var result =await service.SingnUpEmployee(formDto);
            return result.Succeeded ? Ok() : new BadRequestObjectResult(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task Logout()
        {
            await service.Logout();
        }

    }
}
