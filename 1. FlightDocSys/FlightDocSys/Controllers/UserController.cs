using FlightDocSys.Authentication;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _repo;

        public UserController(IUserService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = RoleBase.Admin)]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                return Ok(await _repo.GetAllUserAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = RoleBase.Admin)]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetUserByIdAsync(id);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{email}")]
        [Authorize(Roles = RoleBase.Admin)]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            try
            {
                var Document = await _repo.GetUserByEmailAsync(email);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = RoleBase.Admin)]
        public async Task<IActionResult> UpdateUserAsync(string id, [FromBody] UserView model)
        {
            try
            {
                await _repo.UpdateUserAsync(id, model);
                return Ok(new ObjectResult(new { Status = "Cập nhật thành công" }));
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = RoleBase.Admin)]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteUserAsync(id);
                return Ok(new ObjectResult(new { Status = "Cập nhật thành công" }));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
