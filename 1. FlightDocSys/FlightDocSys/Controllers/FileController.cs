using FlightDocSys.ErrorThrow;
using FlightDocSys.FileHandler;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _repo;

        public FileController(IFileService repo)
        {
            _repo = repo;
        }
        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile(IFormFile file, [FromForm] DocumentFileView model)
        {
            try
            {
                await _repo.PostFileAsync(file, model);
                return Ok();
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

       
        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(string id)
        {
            try
            {
                var result = await _repo.DownloadFileById(id);
                return File(result.Data!,result.Content!,result.Filepath);
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
