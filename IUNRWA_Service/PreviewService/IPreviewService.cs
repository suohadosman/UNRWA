using IUNRWA_DTOs.PreviewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.PreviewService
{
    public interface IPreviewService
    {
        public Task<PreviewFormDto> AddPreview(PreviewFormDto formDto);
        public Task<List<PreviewDto>> GetAllPreviews(int? personId = 0, int? doctorId = 0);
        public Task<PreviewDto> GetPreviewById(int id);

    }
}
