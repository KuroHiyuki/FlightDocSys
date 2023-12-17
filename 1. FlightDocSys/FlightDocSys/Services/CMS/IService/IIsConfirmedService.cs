using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IIsConfirmedService
    {
        public Task<ActionResult<List<IsConfirmedView>>> GetAllIsConfirmAsync();
        public Task<IsConfirmedView> GetIsConfirmByIdAsync(string id);
        public Task<string> IsConfirmAsync(IsConfirmedView model);
    }
}
