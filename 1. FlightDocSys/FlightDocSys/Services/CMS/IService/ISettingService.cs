using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface ISettingService
    {
        public Task<ActionResult<List<SettingView>>> GetSettingAsync();
        //public Task<SettingView> getDocumentDetailViewAsync(string NameDocument);
        //public Task<int> AddDocumentListAsync(DocumentListView model);
        public Task UpdateSettingeAsync(SettingView model);
        //public Task DeleteDocumentListAsync(string NameDocument);
    }
}
