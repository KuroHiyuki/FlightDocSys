using FlightDocSys.Authentication;
using FlightDocSys.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Security.Claims;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _repo;

        public AccountController(IAccountService repo)
        {
            _repo = repo;
        }
        [HttpPost("SignUp")]
        [Authorize(Roles = RoleBase.Admin)]
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
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignIn signInModel)
        {
            var result = await _repo.SignInAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        //[HttpGet("User/{id}")]
        //public async Task<IActionResult> GetUserId(string id)
        //{
        //    return Ok(new {UserId=id});
        //}
        //[HttpGet("User/currentUserId")]
        //public async Task<IActionResult> getUserIdAsync()
        //{
        //    string email = HttpContext.User.FindFirstValue(ClaimTypes.Role);
        //    return Ok(new {email=email});
        //}
    }
}
