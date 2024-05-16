using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.MedicineDto;
using IUNRWA_Model.Entity;
using IUNRWA_Service.LabTestService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestsController : ControllerBase
    {
        private readonly ILabTestService service;

        public LabTestsController(ILabTestService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddLabTestType(string type)
        {
            await service.AddLabTestType(type);
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddLabTest(LabTestFormDto formDto)
        {
            var result = await service.AddLabTest(formDto);
            return Ok(result);
        }
      
      
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllLabTest(int? typeId = 0)
        {
            var result = await service.GetAllLabTest(typeId);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllNCDAnnualLabTest()
        {
            var result = await service.GetNCDAnnualOrMonthlyLabTest();
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllLabeTestTypes()
        {
            var result = await service.GetAllLabTestTypes();
            return Ok(result);
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> RemoveAllLabTests()
        {
            await service.RemoveAllLabTests();
            return Ok();
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> RemoveAllLabTestTypes()
        {
            await service.RemoveAllLabTestTypes();
            return Ok();
        }
    }
    

}
