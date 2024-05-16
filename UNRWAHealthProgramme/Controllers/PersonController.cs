using IUNRWA_DTOs.PersonDto;
using IUNRWA_Service.PersonService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService service;

        public PersonController(IPersonService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPersons(string familyCard=null)
        {
            var result = await service.GetAll(familyCard);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPersonById(int personId)
        {
            var result = await service.GetById(personId);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPersonByChildCard(string childCardNumber)
        {
            var result = await service.GetByChildCard(childCardNumber);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPersonByNCD(string ncdNumber)
        {
            var result = await service.GetByNCD(ncdNumber);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPerson(PersonFormDto formDto)
        {
            await service.AddPeson(formDto);
            return Ok();
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePerson(PersonFormDto formDto)
        {
            await service.UpdatePerson(formDto);
            return Ok();
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> RemovePerson(int personId)
        {
            await service.RemovePerson(personId);
            return Ok();
        }
    }
}
