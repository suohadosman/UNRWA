using IUNRWA_DTOs.NCDDto;
using IUNRWA_Service.NCDService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDController : ControllerBase
    {
        private readonly INCDService service;

        public NCDController(INCDService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetNCDCardDetails( string cardNumber)
        {
            var result = await service.GetNCDCard(cardNumber);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddNCDCard(NCDFormDto formDto)
        {
           var result = await service.AddNCDCard(formDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveNCD(string cardNumber)
        {
             await service.Remove(cardNumber);
            return Ok();
        }
    }
}
