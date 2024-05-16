using IUNRWA_Model.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.UNRWAUsers
{
    public class User: IdentityUser<int>
    {
        public double Salary { get; set; }

    }
}
