using FlightDocSys.Authentication;
using FlightDocSys.Authorize;
using Microsoft.AspNetCore.Identity;

namespace FlightDocSys.Services
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUp model);
        public Task<List<AccountInfo>> SignInAsync(SignIn model);
    }
}
