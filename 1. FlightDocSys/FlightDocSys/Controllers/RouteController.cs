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
    [Authorize]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _repo;

        public RouteController(IRouteService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRouteAsync()
        {
            try
            {
                return Ok(await _repo.GetAllRouteAsync());
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
        public async Task<IActionResult> GetRouteByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetRouteByIdAsync(id);
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
        public async Task<IActionResult> AddRouteAsync(RouteView model)
        {
            try
            {
                var newDocument = await _repo.AddRouteAsync(model);
                var Document = await _repo.GetRouteByIdAsync(newDocument);
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
        public async Task<IActionResult> UpdateRouteAsync(string id, [FromBody] RouteView model)
        {
            try
            {
                await _repo.UpdateRouteAsync(id, model);
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
        public async Task<IActionResult> DeleteRouteAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteRouteAsync(id);
                return Ok(new ObjectResult(new { Status = "Xoá thành công" }));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
