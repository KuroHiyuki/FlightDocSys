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
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _repo;
        public FlightController(IFlightService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllFlightAsync()
        {
            try
            {
                return Ok(await _repo.GetAllFlightAsync());
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
        public async Task<IActionResult> GetFlightByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetFlightByIdAsync(id);
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
        public async Task<IActionResult> GetAllFlightDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllFlightDetailAsync());
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
        public async Task<IActionResult> GetFlightDetailByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetFlightDetailByIdAsync(id);
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
        public async Task<IActionResult> AddDocumentAsync(FlightDetailView model)
        {
            try
            {
                var newDocument = await _repo.AddFlightAsync(model);
                var Document = await _repo.GetFlightDetailByIdAsync(newDocument);
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
        public async Task<IActionResult> UpdateDocumentAsync(string id, [FromBody] FlightDetailView model)
        {
            try
            {
                await _repo.UpdateFlightAsync(id, model);
                return Ok();
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
        public async Task<IActionResult> DeleteDocumentAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteFlightAsync(id);
                return Ok();
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
