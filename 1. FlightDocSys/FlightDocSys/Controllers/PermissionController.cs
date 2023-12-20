using FlightDocSys.ErrorThrow;
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
            catch (ExceptionThrow ex)
            {
                var response = new ObjectResult(new { status = ex.Message })
                {
                    StatusCode = ex.StatusCode
                };
                return response;
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
            catch (ExceptionThrow ex)
            {
                var response = new ObjectResult(new { status = ex.Message })
                {
                    StatusCode = ex.StatusCode
                };
                return response;
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
            catch (ExceptionThrow ex)
            {
                var response = new ObjectResult(new { status = ex.Message })
                {
                    StatusCode = ex.StatusCode
                };
                return response;
            }
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdatePermissionDetailAsync(string id, [FromBody] PermissionView model)
        {
            try
            {
                await _repo.UpdatePermissionDetailAsync(id, model);
                return Ok(new ObjectResult(new { Status = "Cập nhật thành công" }));
            }
            catch (ExceptionThrow ex)
            {
                var response = new ObjectResult(new { status = ex.Message })
                {
                    StatusCode = ex.StatusCode
                };
                return response;
            }

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePermissionDetailAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeletePermissionDetailAsync(id);
                return Ok(new ObjectResult(new { Status = "Xoá thành công" }));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
