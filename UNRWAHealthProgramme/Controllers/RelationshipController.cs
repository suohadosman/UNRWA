using IUNRWA_Service.NationalityService;
using IUNRWA_Service.RelationshipService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipController : ControllerBase
    {
        private readonly IRelationshipService service;

        public RelationshipController(IRelationshipService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllRelationships();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddNationality(List<string> formDto)
        {
            await service.AddRelationship(formDto);
            return Ok();
        }
    }
}
