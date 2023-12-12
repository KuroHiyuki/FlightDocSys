using FlightDocSys.Authentication;
using Microsoft.AspNetCore.Identity;

namespace FlightDocSys.Services
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUp model);
        public Task<string> SignInAsync(SignIn model);
    }
}
