using IUNRWA_DTOs.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.FamilyCardDto
{
    public class FamilyCardDto
    {
        public int Id { get; set; }
        public string FamilyCardNumber { get; set; }
        public List<PersonDto.PersonDto> People { get; set; } = new();
    }
}
