using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;


namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentListControllers : ControllerBase
    {
        private readonly IDocument _DocumentListrepo;
        public DocumentListControllers(IDocument repo)
        {
            _DocumentListrepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDocumentListAsync()
        {
            try
            {
                return Ok(await _DocumentListrepo.GetAllDocumentListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("NameDocument")]
        public async Task<IActionResult> GetDocumentByNameAsynce(string Name)
        {
            var Document = await _DocumentListrepo.GetDocumentDetailViewAsync(Name);
            return Document == null ? NotFound() : Ok(Document);

        }
        //[HttpPut]
        //public async Task<IActionResult> UpdateDocumentAsync(string NameDocument, DocumentView model)
        //{
        //    await _DocumentListrepo.UpdateDocumentListAsync(NameDocument, model);
        //    return NoContent();
        //}
        //[HttpDelete]
        //public async Task<IActionResult> DeleteDocument(string name)
        //{
        //    await _DocumentListrepo.DeleteDocumentListAsync(name);
        //    return NoContent();
        //}
    }
}
