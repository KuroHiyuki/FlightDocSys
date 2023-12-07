using FlightDocSys.Services.CMS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightListControllers : ControllerBase
    {
        private readonly IFlightList _FlightListrepo;


        public FlightListControllers(IFlightList repo)
        {
            _FlightListrepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> getAllDocumentListAsync()
        {
            try
            {
                return Ok(await _FlightListrepo.getAllFlightListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
