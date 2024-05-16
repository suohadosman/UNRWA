using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class Illness:BaseEntity
    {
        public string Name { get; set; }

        public IllnessType IllnessType { get; set; }
        public List<PreviewIllness> PreviewIllnesses { get; set; }
    }
}
