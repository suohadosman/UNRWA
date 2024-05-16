using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class NCDCard :BaseEntity
    {
        public string CardNumber { get; set; }
        public DateTime DateOfCreated { get; set; } = DateTime.Now;
        public int Diabetes { get; set; }
        public bool Pressure { get; set; }
        public string? Sensitive { get; set; }

        public person Person { get; set; }
        public int PersonId { get; set; }

        public List<FollowUpLateComplication> NCDDiagnoses { get; set; } = new();
        public List<FollwUpVisit> FollwUpVisits { get; set; } = new();
        public List<MedicinPreview> MedicinePreviews { get; set; } = new();


    }
}
