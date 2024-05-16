using IUNRWA_Service.RelationshipService;
using IUNRWA_Service.StudyLevelService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyLevelController : ControllerBase
    {
        private readonly IStudyLevelService service;

        public StudyLevelController(IStudyLevelService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllStudyLevel();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddStudyLevel(List<string> formDto)
        {
            await service.AddStudyLevel(formDto);
            return Ok();
        }

    }
}
