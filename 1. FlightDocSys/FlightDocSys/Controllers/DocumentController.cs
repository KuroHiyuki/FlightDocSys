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
        [HttpGet("Document")]
        public async Task<IActionResult> GetAllDocumentListAsync()
        {
            try
            {
                return Ok(await _repo.GetAllDocumentListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("DocumentByName")]
        public async Task<IActionResult> GetDocumentByNameAsync(string Name)
        {
            var Document = await _repo.GetDocumentDetailViewAsync(Name);
            return Document == null ? NotFound() : Ok(Document);

        }
        [HttpPost("Document")]
        public async Task<IActionResult> AddNewDocumentAsync(RecentlyActivtiesView model)
        {
            //var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
            var userId = User.Claims.Where(x => x.Type == "id").FirstOrDefault()?.Value;

            try
            {
                var newDocumentId = await _repo.AddDocumentListAsync(model);
                var Document = await _repo.GetDocumentDetailViewAsync(newDocumentId);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
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
        [HttpGet("DocumentDetail")]
        [Authorize]
        public async Task<IActionResult> GetDocumentDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllDocumentDetailAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("DocumentDetailByName")]
        public async Task<IActionResult> GetOneDocumentDetailAsync(string name)
        {
            try
            {
                return Ok(await _repo.GetOneDocumentDetailAsync(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("DocumentDetail")]
        public async Task<IActionResult> UpdateDocumentDetailAsync(string Name, DocumentDetailView model)
        {
            try
            {
                await _repo.UpdateDocumentDetailAsync(Name, model);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("DocumentDetail")]
        public async Task<IActionResult> DeleteDocumentDetailAsync(string Name)
        {
            try
            {
                await _repo.DeleteDocumentDetailAsync(Name);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
