using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.IllnessDto
{
    public class IllnessDto
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name  { get; set; }
        public string TypeName { get; set; }
        public string Date { set; get; }
    }
}
