using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeListControllers : ControllerBase
    {
        private readonly IDocumentType _repo;
        public DocumentTypeListControllers(IDocumentType repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDocumentTypeListAsync()
        {
            try
            {
                return Ok(await _repo.GetAllDocumentTypeListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetOneDocumentTypeViewAsync(int id)
        {
            var Document = await _repo.GetOneDocumentTypeViewAsync(id);
            return Document == null ? NotFound() : Ok(Document);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateDocumentTypeListAsync(int id, DocumentTypeView model)
        {
            await _repo.UpdateDocumentTypeListAsync(id,model);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            await _repo.DeleteDocumentTypeListAsync(id);
            return NoContent();
        }
    }
}
