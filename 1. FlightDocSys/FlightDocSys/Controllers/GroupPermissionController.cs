﻿using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupPermissionController : ControllerBase
    {
        private readonly IGroupPermissionService _repo;
        public GroupPermissionController(IGroupPermissionService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGroupAsync()
        {
            try
            {
                return Ok(await _repo.GetAllGroupAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetGroupByIdAsync(id);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("FlightDetail")]
        public async Task<IActionResult> GetAllGroupDetailAsync()
        {
            try
            {
                return Ok(await _repo.GetAllGroupDetailAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("FlightDetail/{id}")]
        public async Task<IActionResult> GetGroupDetailByIdAsync(string id)
        {
            try
            {
                var Document = await _repo.GetGroupDetailByIdAsync(id);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("AddFlight")]
        public async Task<IActionResult> AddGroupAsync(GroupDetailView model)
        {
            try
            {
                var newDocument = await _repo.AddGroupAsync(model);
                var Document = await _repo.GetGroupDetailByIdAsync(newDocument);
                return Document == null ? NotFound() : Ok(Document);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateFlight/{id}")]
        public async Task<IActionResult> UpdateGroupAsync(string id, [FromBody] GroupDetailView model)
        {
            try
            {
                if (id != model.GroupId)
                {
                    return NotFound();
                }
                await _repo.UpdateGroupAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("DeleteFlight/{id}")]
        public async Task<IActionResult> DeleteGrouptAsync([FromRoute] string id)
        {
            try
            {
                await _repo.DeleteGrouptAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
