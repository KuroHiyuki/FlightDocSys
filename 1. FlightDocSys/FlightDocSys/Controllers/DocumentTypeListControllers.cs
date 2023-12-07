using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeListControllers : ControllerBase
    {
        private readonly IDocumentTypeList _repo;
        public DocumentTypeListControllers(IDocumentTypeList repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> getAllDocumentTypeListAsync()
        {
            try
            {
                return Ok(await _repo.getAllDocumentTypeListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> getOneDocumentTypeViewAsync(int id)
        {
            var Document = await _repo.getOneDocumentTypeViewAsync(id);
            return Document == null ? NotFound() : Ok(Document);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateDocumentTypeListAsync(int id, DocumentTypeListView model)
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
