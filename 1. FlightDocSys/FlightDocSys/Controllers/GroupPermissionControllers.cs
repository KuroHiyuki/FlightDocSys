using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using FlightDocSys.Services.CMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupPermissionControllers : ControllerBase
    {
        private readonly IGroupPermission _repo;
        public GroupPermissionControllers(IGroupPermission repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetGroupPermissionAsync() 
        {
            try
            {
                return Ok(await _repo.GetAllGroupPermisionListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("name")]
        public async Task<IActionResult> GetOneGroupPermissionAsync(string Name)
        {
            var Document = await _repo.GetOneGroupPermissionViewAsync(Name);
            try
            {
                return Ok(Document);
            }
            catch
            {
                return NotFound(Name);
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> AddGroupPermissionAsync(Services.CMS.Service.GroupPermission model)
        //{
        //    try
        //    {
        //        //await _repo.AddGroupPerissionListAsync(model)
        //        return NoContent();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
        [HttpPut("name")]
        public async Task<IActionResult> UpadateGroupPermissionAysnce(string Name, GroupPermissionView model)
        {
            try
            {
                await _repo.UpdateGroupPermissionListAsync(Name, model);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("name")]
        public async Task<IActionResult> DeleteGroupPermission(string name)
        {
            try
            {
                await _repo.DeleteGroupPermissionListAsync(name);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
