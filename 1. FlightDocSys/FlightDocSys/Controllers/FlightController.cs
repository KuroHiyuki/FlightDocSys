using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
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
        public async Task<IActionResult> GetAllFlightAsync()
        {
            try
            {
                return Ok(await _repo.GetAllFlightAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetFlightByIdAsync(id);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("FlightDetail")]
        public async Task<IActionResult> GetAllFlightDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllFlightDetailAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("FlightDetail/{id}")]
        public async Task<IActionResult> GetFlightDetailByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetFlightDetailByIdAsync(id);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("AddFlight")]
        public async Task<IActionResult> AddDocumentAsync(FlightDetailView model)
        {
            try
            {
                var newDocument = await _repo.AddFlightAsync(model);
                var Document = await _repo.GetFlightDetailByIdAsync(newDocument);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateFlight/{id}")]
        public async Task<IActionResult> UpdateDocumentAsync(string id, [FromBody] FlightDetailView model)
        {
            try
            {
                if (id != model.FlightId)
                {
                    return NotFound();
                }
                await _repo.UpdateFlightAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("DeleteFlight/{id}")]
        public async Task<IActionResult> DeleteDocumentAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteFlightAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
