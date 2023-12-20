using FlightDocSys.ErrorThrow;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupPermissionController : ControllerBase
    {
        private readonly IGroupPermissionService _repo;
        public GroupPermissionController(IGroupPermissionService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllGroupAsync()
        {
            try
            {
                return Ok(await _repo.GetAllGroupAsync());
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
        [Authorize]
        public async Task<IActionResult> GetGroupByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetGroupByIdAsync(id);
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
        [HttpGet("FlightDetail")]
        [Authorize]
        public async Task<IActionResult> GetAllGroupDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllGroupDetailAsync());
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
        [HttpGet("FlightDetail/{id}")]
        [Authorize]
        public async Task<IActionResult> GetGroupDetailByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetGroupDetailByIdAsync(id);
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
        [HttpPost("AddFlight")]
        [Authorize]
        public async Task<IActionResult> AddGroupAsync(GroupDetailView model)
        {
            try
            {
                var newDocument = await _repo.AddGroupAsync(model);
                var Document = await _repo.GetGroupDetailByIdAsync(newDocument);
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
        [HttpPut("UpdateFlight/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateGroupAsync(string id, [FromBody] GroupDetailView model)
        {
            try
            {
                await _repo.UpdateGroupAsync(id, model);
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

        [HttpDelete("DeleteFlight/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteGrouptAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteGrouptAsync(id);
                return Ok(new ObjectResult(new { Status = "Xoá thành công" }));
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
    }
}
