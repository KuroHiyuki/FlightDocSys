using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IGroupPermission
    {
        public Task<ActionResult<List<GroupPermissionView>>> GetAllGroupPermisionListAsync();
        public Task<GroupPermissionView> GetOneGroupPermissionViewAsync(string Name);
        //public Task<string> AddGroupPerissionListAsync(GroupPermissionView model);
        public Task UpdateGroupPermissionListAsync(string Name, GroupPermissionView model);
        public Task DeleteGroupPermissionListAsync(string Name);
    }
}
