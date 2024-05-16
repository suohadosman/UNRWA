using IUNRWA_DTOs.AuthenticationDto;
using IUNRWA_DTOs.Views;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.AuthenticationService
{
    public interface IAuthenticationService
    {
        public Task<IdentityResult> SingnUpEmployee(SignUpEmployeeFormDto formDto);
        public Task<SignInResult> Login(LoginFormDto formDto);
        public Task Logout();


    }
}
