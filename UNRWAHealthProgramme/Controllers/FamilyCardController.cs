using IUNRWA_DTOs.FamilyCardDto;
using IUNRWA_Service.FamilyCardService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyCardController : ControllerBase
    {
        private readonly IFamilyCardService service;

        public FamilyCardController(IFamilyCardService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllFamilyCards();
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetFamilyCard(int id =0, string familyCardNumber = null)
        {
            var result = await service.GetFamilyCard(id, familyCardNumber);
            return Ok(result);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddFamilyCard( FamilyCardFormDto formDto)
        {
            await service.AddFamilyCard(formDto);
            return Ok();
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> RemoveFamilyCard(int id)
        {
            await service.RemoveFamilyCard(id);
            return Ok();
        }

    }
}
