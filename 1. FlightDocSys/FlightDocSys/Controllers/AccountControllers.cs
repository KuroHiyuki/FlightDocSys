using FlightDocSys.Authentication;
using FlightDocSys.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountControllers : ControllerBase
    {
        private readonly IAccountService _repo;

        public AccountControllers(IAccountService repo) 
        {
            _repo = repo;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUp signUpModel)
        {
            var result = await _repo.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignIn signInModel)
        {
            var result = await _repo.SignInAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
