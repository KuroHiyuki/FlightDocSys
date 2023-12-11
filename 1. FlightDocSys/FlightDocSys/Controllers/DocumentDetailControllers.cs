using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentDetailControllers : ControllerBase
    {
        private readonly IDocumentDetail _repo;

        public DocumentDetailControllers(IDocumentDetail repo) 
        { 
            _repo = repo;
        }
        [HttpGet]
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
        [HttpGet("Name")]
        public async Task<IActionResult> GetOneDocumentDetailAsync(string name)
        {
            try
            {
                return Ok(await _repo.GetOneDocumentDetailAsync(name));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDocumentDetailAsync(string Name,DocumentDetailView model)
        {
            try
            {
                await _repo.UpdateDocumentDetailAsync(Name,model);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
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
