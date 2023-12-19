﻿using FlightDocSys.ErrorThrow;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _repo;

        public SettingController(ISettingService repo) 
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetSetttingAsync()
        {
            try
            {
                return Ok(await _repo.GetSettingAsync());
            }
            catch (ExceptionThrow ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSettingAsync(SettingView model)
        {
            await _repo.UpdateSettingeAsync(model);
            return NoContent();
        }
    }
}
