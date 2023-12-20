using FlightDocSys.FileHandler;
using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface ISettingService
    {
        public Task<ActionResult<List<SettingView>>> GetSettingAsync();
        //public Task<SettingView> getDocumentDetailViewAsync(string NameDocument);
        //public Task<int> AddDocumentListAsync(DocumentListView model);
        public Task UpdateSettingeAsync(SettingInputView_1 model);
        //public Task DeleteDocumentListAsync(string NameDocument);
        public Task PostLogoAsync(IFormFile fileData, SettingInputView_1 model);
        public Task UpdateLogoAsync(IFormFile fileData, LogoFileView model);
    }
}
