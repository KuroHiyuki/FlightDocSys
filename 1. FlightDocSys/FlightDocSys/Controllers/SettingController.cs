using FlightDocSys.ErrorThrow;
using FlightDocSys.FileHandler;
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
                var response = new ObjectResult(new { status = ex.Message })
                {
                    StatusCode = ex.StatusCode
                };
                return response;
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSettingAsync([FromForm]SettingInputView_1 model)
        {
            try
            {
                await _repo.UpdateSettingeAsync(model);
                return Ok(new ObjectResult(new { Status = "Cập nhật thành công" }));
            }
            catch (ExceptionThrow ex)
            {
                var response = new ObjectResult(new { status = ex.Message })
                {
                    StatusCode = ex.StatusCode,
                };
                return response;
            }
            
        }
        [HttpPost("AddLogo")]
        public async Task<IActionResult> AddLogoAsync(IFormFile files, [FromForm] SettingInputView_1 model)
        {
            try
            {
                await _repo.PostLogoAsync(files, model);
                return Ok(new ObjectResult(new { Status = "Thêm thành công" }));
            }
            catch (ExceptionThrow ex)
            {
                var response = new ObjectResult(new { status = ex.Message })
                {
                    StatusCode = ex.StatusCode,
                };
                return response;
            }
        }
        [HttpPut("uploadLogo")]
        public async Task<IActionResult> OnUpdateLogoAsync(IFormFile files,[FromForm]LogoFileView model)
        {
            try
            {
                await _repo.UpdateLogoAsync(files, model);
                return Ok(new ObjectResult(new { Status = "Cập nhật thành công" }));
            }
            catch (ExceptionThrow ex)
            {
                var response = new ObjectResult(new { status = ex.Message })
                {
                    StatusCode = ex.StatusCode,
                };
                return response;
            }
        }
    }
}
