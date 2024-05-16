using IUNRWA_DTOs.NewFolder;
using IUNRWA_DTOs.TheMeasurementDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.TheMeasurementService
{
    public interface ITheMeasurementService
    {
        public Task<TheMeasurementFormDto> AddMeasurement(TheMeasurementFormDto formDto);
        public Task<List<TheMeasurementDto>> GetAllMeasurements();
        public Task<TheMeasurementFormDto> AddPersonMeasurement(TheMeasurementFormDto formDto);
        public Task<List<TheMeasurementDto>> GetAllPersonMeasurements(int? personId = 0, int? meId = 0);
        public Task<TheMeasurementFormDto> AddPreviewMeasurement(TheMeasurementFormDto formDto);
        public Task RequestNCDMeasurement(int personId, int followUpVisitId);

        public Task<List<MeasurementQueueDto>> GetMeasurementQueue();
        public Task<List<TheMeasurementDto>> GetAllUnDonePersonMeasurements(int personId);
        public Task AddMeasurementResult(int id, float result);

    }
}
