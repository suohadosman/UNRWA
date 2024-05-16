using IUNRWA_DTOs.MedicineDto;
using IUNRWA_DTOs.MedicineTypeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.MedicineService
{
    public interface IMedicineService
    {
        public Task<MedicineFormDto> AddMedicine(MedicineFormDto dto);
        public Task<List<MedicineDto>> GetAllMedicine(int? typeId = 0);
        public Task AddMedicineType(string type);
        public Task<List<MedicineTypeDto>> GetAllMedicineType();



    }
}
