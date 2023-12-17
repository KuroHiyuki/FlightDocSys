using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _repo;

        public PermissionController(IPermissionService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPermissionDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllPermissionDetailAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightDetailByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetPermissionDetailByIdAsync(id);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddPermissionDetailAsync(PermissionView model)
        {
            try
            {
                var newDocument = await _repo.AddPermissionDetailAsync(model);
                var Document = await _repo.GetPermissionDetailByIdAsync(newDocument);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdatePermissionDetailAsync(string id, [FromBody] PermissionView model)
        {
            try
            {
                if (id != model.PermissionId)
                {
                    return NotFound();
                }
                await _repo.UpdatePermissionDetailAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePermissionDetailAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeletePermissionDetailAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
