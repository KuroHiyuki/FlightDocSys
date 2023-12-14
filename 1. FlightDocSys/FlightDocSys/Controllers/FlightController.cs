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
        [HttpGet("Flight")]
        public async Task<IActionResult> GetAllDocumentListAsync()
        {
            try
            {
                return Ok(await _repo.getAllFlightListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("FlightDetail")]
        public async Task<IActionResult> GetFlightDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllFlightDetailAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Name")]
        public async Task<IActionResult> GetOneFlightDetailAsync(string Name)
        {
            try
            {
                return Ok(await _repo.GetOneFlightDetailAsync(Name));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
