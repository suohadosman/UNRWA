using IUNRWA_DTOs.MedicineDto;
using IUNRWA_Service.MedicineService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UNRWAHealthProgramme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService service;

        public MedicinesController(IMedicineService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddMedicineType(string type)
        {
           await service.AddMedicineType(type);
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddMedicines(MedicineFormDto formDto)
        {
            var result = await service.AddMedicine(formDto);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetMedicines(int? typeId =0)
        {
            var result = await service.GetAllMedicine(typeId);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetMedicineType()
        {
            var result = await service.GetAllMedicineType();
            return Ok(result);
        }
    }
}
