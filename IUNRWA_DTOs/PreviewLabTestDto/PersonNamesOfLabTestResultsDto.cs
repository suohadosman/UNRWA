namespace IUNRWA_DTOs.PreviewLabTestDto
{
    public class PersonNamesOfLabTestResultsDto
    {
        public int PersonId { set; get; }
        public string PersonName { set; get; }
        public List<DatesOfLabTestResultsDto> LabTestsDates { set; get; }= new();    
    }
}
