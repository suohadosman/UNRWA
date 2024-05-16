using IUNRWA_DTOs.NewFolder;
using IUNRWA_DTOs.PersonDto;
using IUNRWA_Model.Entity;
using IUNRWA_Service.TheMeasurementService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheMeasurementController : ControllerBase
    {
        private readonly ITheMeasurementService theMeasurementService;

        public TheMeasurementController(ITheMeasurementService theMeasurementService)
        {
            this.theMeasurementService = theMeasurementService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddMeasurement(TheMeasurementFormDto formDto)
        {
            var result =await theMeasurementService.AddMeasurement(formDto);
            return Ok(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddPersonMeasurement(TheMeasurementFormDto formDto)
        {
            var result = await theMeasurementService.AddPersonMeasurement(formDto);
            return Ok(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RequestNCDMeasurements(int personId, int followUpVisitId)
        {
            await theMeasurementService.RequestNCDMeasurement(personId, followUpVisitId);
            return Ok();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllMeasurements()
        {
            var result = await theMeasurementService.GetAllMeasurements();
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetMeasurementQueue()
        {
            var result = await theMeasurementService.GetMeasurementQueue();
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPersonMeasurements(int? personId = 0, int? meId = 0)
        {
            var result = await theMeasurementService.GetAllPersonMeasurements(personId, meId);
            return Ok(result);
        }
    }
}
