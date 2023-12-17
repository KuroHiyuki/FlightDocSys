using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsConfirmController : ControllerBase
    {
        private readonly IIsConfirmedService _repo;

        public IsConfirmController(IIsConfirmedService repo) 
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIsConfirmAsync()
        {
            try
            {
                return Ok(await _repo.GetAllIsConfirmAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIsConfirmByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetIsConfirmByIdAsync(id);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("AddFlight")]
        public async Task<IActionResult> AddGroupAsync(IsConfirmedView model)
        {
            try
            {
                var New = await _repo.IsConfirmAsync(model);
                var Document = await _repo.GetIsConfirmByIdAsync(New);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
