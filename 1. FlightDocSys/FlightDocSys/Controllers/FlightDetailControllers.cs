using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightDetailControllers : ControllerBase
    {
        private readonly IFlightDetail _repo;

        public FlightDetailControllers(IFlightDetail repo) 
        { 
            _repo = repo;
        }
        [HttpGet]
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
