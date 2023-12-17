using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _repo;
        public CategoryController(ICategoryService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            try
            {
                return Ok(await _repo.GetAllCategoryAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetCategoryByIdAsync(id);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("CategoryDetail")]
        public async Task<IActionResult> GetAllCategoryDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllCategoryDetailAsync());
            }
            catch 
            { 
                return BadRequest(); 
            }
        }
        [HttpGet("CategoryDetail/{id}")]
        public async Task<IActionResult> GetCategoryDetailByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetCategoryDetailByIdAsync(id);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddNewCategoryDetailAsync(CategoryDetailView model)
        {
            try
            {
                return Ok(await _repo.AddCategoryAsync(model));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(string id, [FromBody] CategoryDetailView model)
        {
            try
            {
                await _repo.UpdateCategoryAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteCategoryAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
