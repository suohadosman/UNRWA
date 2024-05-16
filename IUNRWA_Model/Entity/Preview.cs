using IUNRWA_Model.UNRWAUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class Preview : BaseEntity
    {
        public DateTime Date { get; set; }

        public Doctor Doctor { get; set; }
        public person Patient { get; set; }
        public int? ReservationId { set; get; }
        public Reservation? Reservation { set; get; }
        public List<MedicinPreview> MedicinPreviews { get; set; } = new();
        public List<PreviewIllness> PreviewIllnesses { get; set; } = new();
        public List<PreviewComplaint> PreviewComplaints { get; set; }
        public List<PreviewLabTest> LabTests { get; set; }
        public List<PersonMeasurementResult> Measurements = new();
    }
}
