using IUNRWA_ShareKernal.Enum.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.AuthenticationDto
{
    public class SignUpEmployeeFormDto
    {
        public int PersonId { get; set; }
        public int TeamId { get; set; }
        public int HealthCenterId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public double Salary { get; set; }
        public UserType EmployeeType { get; set; }

    }
}
