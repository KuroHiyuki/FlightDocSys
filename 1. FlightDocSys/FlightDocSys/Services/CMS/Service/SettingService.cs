using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FlightDocSys.Services.CMS.Service
{
    public class SettingService : ISettingService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public SettingService(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<List<SettingView>>> GetSettingAsync()
        {
            var setting = await _context.Settings.Include(dt => dt.User).ToListAsync();
            return _mapper.Map<List<SettingView>>(setting);
        }

        public async Task UpdateSettingeAsync(SettingView model)
        {
            var UpdateSetting = _mapper.Map<Models.Entities.Setting>(model);
            _context.Settings.Update(UpdateSetting);
            await _context.SaveChangesAsync();
        }
    }
}
