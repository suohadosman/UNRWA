using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.Views
{
    public class InsertLabTestResultDto
    {
        public int PreviewLabTestId { get; set; }
        public bool PNResult { set; get; }
        public float ValueResult { set; get; }
        public int FollowUpLabTestId { set; get; }
        public IUNRWA_Model.UNRWAUsers.Tester User { set; get; }

    }
}
