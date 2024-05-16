using IUNRWA_DTOs.PreviewMedicineDto;
using IUNRWA_Model.UNRWAUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.Views
{
    public class PharmacistViewDto
    {
        public List<PeronToTakePreviewMedicineDto> RecipePersonsInfo { set; get; } = new();
        public List<PreviewMedicineDto.PreviewMedicineDto> UnTakenPreviewMedicines { set; get; } = new();
        public List<PreviewMedicineDto.PreviewMedicineDto> AllTakenPreviewMedicines { set; get; } = new();
        public Pharmacist User { set; get; }
    }
}
