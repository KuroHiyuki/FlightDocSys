using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS;
using Microsoft.AspNetCore.Mvc;


namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentListControllers : ControllerBase
    {
        private readonly IDocumentList _DocumentListrepo;
        public DocumentListControllers(IDocumentList repo)
        {
            _DocumentListrepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> getAllDocumentListAsync()
        {
            try
            {
                return Ok(await _DocumentListrepo.getAllDocumentListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("NameDocument")]
        public async Task<IActionResult> GetDocumentByNameAsynce(string Name)
        {
            var Document = await _DocumentListrepo.getDocumentDetailViewAsync(Name);
            return Document == null ? NotFound() : Ok(Document);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateDocumentAsync(string NameDocument, DocumentListView model)
        {
            await _DocumentListrepo.UpdateDocumentListAsync(NameDocument, model);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDocument(string name)
        {
            await _DocumentListrepo.DeleteDocumentListAsync(name);
            return NoContent();
        }
    }
}
