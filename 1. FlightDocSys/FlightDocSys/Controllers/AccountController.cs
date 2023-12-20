using FlightDocSys.Authentication;
using FlightDocSys.Authorize;
using FlightDocSys.ErrorThrow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Linq.Expressions;
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
        //[Authorize(Roles = RoleBase.Admin)]
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
            
            try 
            {
                var result = await _repo.SignInAsync(signInModel);
                return Ok(result);
            }
            catch (ExceptionThrow ex)
            {
                var response = new ObjectResult(new { status = ex.Message})
                {
                    StatusCode = ex.StatusCode
                };
                return response;
            }
            
        }
    }
}
