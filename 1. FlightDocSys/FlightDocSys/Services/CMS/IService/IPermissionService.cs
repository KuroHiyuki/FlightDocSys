using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IPermissionService
    {
        public Task<ActionResult<List<PermissionView>>> GetAllPermissionDetailAsync();
        public Task<PermissionView> GetPermissionDetailByIdAsync(string id);
        public Task<string> AddPermissionDetailAsync(PermissionView model);
        public Task UpdatePermissionDetailAsync(string id, PermissionView model);
        public Task DeletePermissionDetailAsync(string id);
    }
}
