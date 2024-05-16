using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_ShareKernal.Enum
{
    public class ErrorMessages
    {
        public static string PreviewNotFound => nameof (PreviewNotFound);
        public static string LabTestNotFound => nameof(LabTestNotFound);
        public static string PreviewLabTestNotFound => nameof(PreviewLabTestNotFound);
        public static string MeasurementNotFound => nameof(MeasurementNotFound);
        public static string FollowUpNotFound => nameof(FollowUpNotFound);
        public static string FollowUpLabTestNotFound => nameof(FollowUpLabTestNotFound);

        public static string PersonNotFound => nameof(PersonNotFound);
        public static string FollowUpVisit => nameof(FollowUpVisit);
    }
}
