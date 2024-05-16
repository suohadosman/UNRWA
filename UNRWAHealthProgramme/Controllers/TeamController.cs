using IUNRWA_Service.TeamService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService service;

        public TeamController(ITeamService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var result = await service.GetAllTeams();
            return Ok(result);
        }

       
        [HttpPost]
        public async Task<IActionResult> Post(List<string> teams)
        {
            await service.AddTeams(teams);
            return Ok();
        }

       
    }
}
