using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.LateComplicationDto
{
    public class PersonLateComplicationDto
    {
        public int Id { get; set; } 
        public bool Status {  set; get; }
        public int LateComplicationId { get; set; }
        public string LateComplicationName { get; set; }
        public string FollowUpVisitDate { set; get; }

    }
}
