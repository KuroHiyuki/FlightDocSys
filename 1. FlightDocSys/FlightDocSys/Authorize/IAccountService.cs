using FlightDocSys.Authentication;
using Microsoft.AspNetCore.Identity;

namespace FlightDocSys.Authorize
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUp model);
        public Task<List<AccountInfo>> SignInAsync(SignIn model);
    }
}
