using FlightDocSys.ErrorThrow;
using FlightDocSys.FileHandler;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _repo;
        public DocumentController(IDocumentService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDocumentAsync()
        {
            try
            {
                return Ok(await _repo.GetAllDocumentAsync());
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
        public async Task<IActionResult> GetDocumentByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetDocumentByIdAsync(id);
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
        [HttpGet("DocumentDetail")]
        public async Task<IActionResult> GetAllDocumentDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllDocumentDetailAsync());
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
        [HttpGet("DocumentDetail/{id}")]
        public async Task<IActionResult> GetCategoryDetailByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetDocumentDetailByIdAsync(id);
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
        //[HttpPost("AddDocument")]
        //public async Task<IActionResult> AddDocumentAsync(DocumentDetailView model)
        //{
        //    try
        //    {
        //        var newDocument = await _repo.AddDocumentAsync(model);
        //        var Document = await _repo.GetDocumentDetailByIdAsync(newDocument);
        //        return Document == null ? NotFound() : Ok(Document);
        //    }
        //    catch (ExceptionThrow ex)
        //    {
        //        var response = new ObjectResult(new { status = ex.Message })
        //        {
        //            StatusCode = ex.StatusCode
        //        };
        //        return response;
        //    }
        //}
        [HttpPut("UpdateDocument/{id}")]
        public async Task<IActionResult> UpdateDocumentAsync(string id, [FromBody] DocumentUpdateView_1 model)
        {
            try
            {
                await _repo.UpdateDocumentAsync(id, model);
                return Ok(new ObjectResult(new { Status = "Cập nhật thành công" }));
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

        [HttpDelete("DeleteDocument/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDocumentAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteDocumentAsync(id);
                return Ok(new ObjectResult(new { Status = "Xoá thành công" }));
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
        [HttpPost("UploadFile")]
        public async Task<ActionResult> PostSingleFile(IFormFile file, [FromForm] DocumentFileView model)
        {
            try
            {
                await _repo.PostFileAsync(file, model);
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
        [HttpPost("UpdatedFile")]
        public async Task<ActionResult> UpdateFileAsync(IFormFile file, [FromForm] DocumentUpdateView_2 model)
        {
            try
            {
                await _repo.UpdateFileAsync(file, model);
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

        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(string id)
        {
            try
            {
                var result = await _repo.DownloadFileById(id);
                return File(result.Data!, result.Content!, result.Filepath);
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
