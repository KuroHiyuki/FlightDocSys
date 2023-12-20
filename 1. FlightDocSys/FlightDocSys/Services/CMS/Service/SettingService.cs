using AutoMapper;
using FlightDocSys.ErrorThrow;
using FlightDocSys.FileHandler;
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
            var setting = await _context.Settings.ToListAsync();
            return _mapper.Map<List<SettingView>>(setting);
        }
        public async Task PostLogoAsync(IFormFile fileData, SettingInputView_1 model)
        {
            try
            {
                var fileDetails = _mapper.Map<Setting>(model);
                fileDetails.UserId = model.UserId;
                fileDetails.UpdateDate = DateTime.Now;
                fileDetails.NameLogo = fileData.FileName;
                string[] parts = fileData.FileName!.Split(".");
                fileDetails.fileLogo = parts[1] switch
                {
                    "png" => (FileLogo)1,
                    "jpeg" => (FileLogo)2,
                    _ => 0,
                };
                if (fileDetails.fileLogo == 0)
                {
                    throw new ExceptionThrow(405, "Kiểu File không hợp lệ");
                }
                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.Data = stream.ToArray();
                }
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "FileHandler\\Logo", fileDetails.NameLogo!);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await fileData.CopyToAsync(stream);
                }
                fileDetails.FilePath = filepath;
                await _context.Settings.AddAsync(fileDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateSettingeAsync(SettingInputView_1 model)
        {
            var UpdateSetting = _mapper.Map<Models.Entities.Setting>(model);
            _context.Settings.Update(UpdateSetting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLogoAsync(IFormFile fileData, LogoFileView model)
        {
            try
            {
                var setting = _context.Settings.FirstOrDefaultAsync(dt => dt.UserId == model.UserId);
                //var fileDetails = _mapper.Map<Setting>(model);
                //fileDetails.UserId = model.UserId;
                setting.Result!.NameLogo = fileData.FileName ;
                string[] parts = setting.Result.NameLogo!.Split(".");
                setting.Result.fileLogo = parts[1] switch
                {
                    "png" => (FileLogo)1,
                    "jpeg" => (FileLogo)2,
                    _ => 0,
                };
                if (setting.Result.fileLogo == 0)
                {
                    throw new ExceptionThrow(405, "Kiểu File không hợp lệ");
                }
                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    setting.Result.Data = stream.ToArray();
                }
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "FileHandler\\Logo", setting.Result.NameLogo!);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await fileData.CopyToAsync(stream);
                }
                setting.Result.FilePath = filepath;
                _context.Settings.Update(setting.Result);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
