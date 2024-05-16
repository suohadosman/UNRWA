using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.PersonDto;
using IUNRWA_DTOs.PreviewLabTestDto;
using IUNRWA_Model.UNRWAUsers;
using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.Tester
{
    public class TesterDto
    {
        public List<LabTestDto.LabTestDto> AllLabTest { set; get; } = new();
        public LabTestFormDto LabTestToAdd { set; get; }
        public List<LabTestTypeDto> LabTestTypes { set; get; } = new();
        public int LabTestTypeId { set; get; }
        public string LabTestName { set; get; }
        public double NormalLabTestSingleValue { set; get; }
        public double MinValue { set; get; }
        public double MaxValue { set; get; }
        public bool TrueFalse { set; get; }
        public bool IsAvilable { set; get; }
        public string? Unit { set; get; }
        public List<LabTestResultDto> Queue { get; set; } = new();
        public List<LabTestResultDto> DoneLabTest { get; set; } = new();

        public List<PersonNamesOfLabTestResultsDto> PersonNamesOfLabTestResults { get; set; } = new();
        public List<DatesOfLabTestResultsDto> DatesOfLabTestResults { get; set; } = new();
        public List<LabTestResultDto> PersonLabTestResultInDate { get; set; } = new();
        public PersonDto.PersonDto PersonInfo { set; get; }
        public string DateOfLabTest { set; get; }
        public IUNRWA_Model.UNRWAUsers.Tester User { set; get; }
    }
}
