using FlightDocSys.Authentication;
using FlightDocSys.ErrorThrow;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize()]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            try
            {
                return Ok(await _repo.GetAllCategoryAsync());
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
        [Authorize]
        public async Task<IActionResult> GetCategoryByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetCategoryByIdAsync(id);
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
        [HttpGet("CategoryDetail")]
        [Authorize]
        public async Task<IActionResult> GetAllCategoryDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllCategoryDetailAsync());
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
        [HttpGet("CategoryDetail/{id}")]
        [Authorize]
        public async Task<IActionResult> GetCategoryDetailByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetCategoryDetailByIdAsync(id);
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
        [HttpPost("AddCategory")]
        [Authorize]
        public async Task<IActionResult> AddNewCategoryDetailAsync(CategoryDetailView model)
        {
            try
            {
                return Ok(await _repo.AddCategoryAsync(model));
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
        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(string id, [FromBody] CategoryDetailView model)
        {
            try
            {
                await _repo.UpdateCategoryAsync(id, model);
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

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteCategoryAsync(id);
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
    }
}
