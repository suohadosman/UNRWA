using IUNRWA_DTOs.ChildCardDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.ChildCardService
{
    public interface IChildCardService
    {
        public  Task AddChildCard(ChildCardFormDto formDto);

    }
}
