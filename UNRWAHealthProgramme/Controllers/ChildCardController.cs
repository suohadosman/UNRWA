using IUNRWA_DTOs.ChildCardDto;
using IUNRWA_Service.ChildCardService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildCardController : ControllerBase
    {
        private readonly IChildCardService service;

        public ChildCardController(IChildCardService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddChildCard(ChildCardFormDto formDto)
        {
           await service.AddChildCard(formDto);
            return Ok();
        }
    }
}
