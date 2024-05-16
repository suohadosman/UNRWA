using IUNRWA_DTOs.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IUNRWA_DTOs.FamilyCardDto
{
    public class FamilyCardFormDto
    {
        public string CardNumber { set; get; }
        public int Id { get; set; } = new();
    }
}
