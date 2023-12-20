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
    //[Authorize]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _repo;

        public SettingController(ISettingService repo) 
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetSetttingAsync()
        {
            try
            {
                return Ok(await _repo.GetSettingAsync());
            }
            catch (ExceptionThrow ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSettingAsync(SettingView model)
        {
            await _repo.UpdateSettingeAsync(model);
            return NoContent();
        }
        [HttpPost("uploadLogo")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using var stream = System.IO.File.Create(filePath);
                    await formFile.CopyToAsync(stream);
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size });
        }
    }
}
