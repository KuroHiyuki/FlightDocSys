using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightListControllers : ControllerBase
    {
        private readonly IFlight _FlightListrepo;


        public FlightListControllers(IFlight repo)
        {
            _FlightListrepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDocumentListAsync()
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
