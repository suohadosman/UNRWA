using IUNRWA_DTOs.MedicineDto;
using IUNRWA_DTOs.PreviewMedicineDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.PreviewMedicineService
{
    public interface IPreviewMedicineService
    {
        public Task<PreviewMedicineFormDto> AddPreviewMedicine(PreviewMedicineFormDto formDto);
        public Task<List<PreviewMedicineDto>> GetAllTakenPreviewMedicine(int? personId = 0, int? typeId =0);
        public Task UpdatePreviewMedicine(PreviewMedicineFormDto formDto);
        public Task<List<PeronToTakePreviewMedicineDto>> GetAllPersonNamesToTakePreviewMedicine();
        public Task<List<PreviewMedicineDto>> GetAllUnTakenPreviewMedicine();
        public Task TakePreviewMedicine(int personId);
        public Task UnTakePreviewMedicine(int previewMedicineId);
        public Task<List<PreviewMedicineDto>> GetAllPreviewMedicine(int? personId = 0, int? typeId = 0);
        public Task<List<PreviewMedicineDto>> GetAllNCDPreviewMedicine(int? personId = 0, int? typeId = 0);

        public Task<PreviewMedicineFormDto> RequestNcdPreviewMedicine(PreviewMedicineFormDto formDto);
        public Task<List<MedicineDto>> GetAllPatientMedicines(int personId);

    }
}
