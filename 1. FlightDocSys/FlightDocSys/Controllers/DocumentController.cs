using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("DocumentDetail")]
        public async Task<IActionResult> GetAllDocumentDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllDocumentDetailAsync());
            }
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("AddDocument")]
        public async Task<IActionResult> AddDocumentAsync(DocumentDetailView model)
        {
            try
            {
                var newDocument = await _repo.AddDocumentAsync(model);
                var Document = await _repo.GetDocumentDetailByIdAsync(newDocument);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateDocument/{id}")]
        public async Task<IActionResult> UpdateDocumentAsync(string id, [FromBody] DocumentDetailView model)
        {
            try
            {
                if (id != model.CategoryId)
                {
                    return NotFound();
                }
                await _repo.UpdateDocumentAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("DeleteDocument/{id}")]
        public async Task<IActionResult> DeleteDocumentAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteDocumentAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
