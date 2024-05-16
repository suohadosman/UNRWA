using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.LabTestDto
{
    public class LabTestResultDto
    {
        public int? PreviewLabTestId { get; set; }
        public int LabTestId { get; set; }
        public int? PreviewId { get; set; }
        public int PersonId { get; set; }
        public float? Result { get; set; }
        public string? Unit { get; set; }
        public DateTime Date { get; set; }
        public string LabTestName { get; set; }
        public int LabTestTypeId { get; set; }
        public LabTestResultType LabTestTypeName { get; set; }
        public bool IsDone { get; set; }
        public string PersonName { get; set; }
        public string DoctorName { set; get; }
        public bool IsQuick { set; get; }
        public LabTestResultType? ResultType { set; get; }
        public int? FollowUpId { get; set; }
        public int? FollowUpLabTestId { get; set; }
        public FollowUpLabTestType FollowUpLabTestType { get; set; }
        public bool? PNResult { set; get; }
        public string HealthCenter { set; get; }
        public string LabTestType { set; get; }
        public string date2 { set; get; }

    }
}
