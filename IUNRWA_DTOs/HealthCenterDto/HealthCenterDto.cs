using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.HealthCenterDto
{
    public class HealthCenterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AreaPlaceId { get; set; }
        public string AreaPlaceName { get; set; }
    }
}
