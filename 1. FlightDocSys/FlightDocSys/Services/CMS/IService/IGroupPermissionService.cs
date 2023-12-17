using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IGroupPermissionService
    {
        #region Short View
        public Task<ActionResult<List<GroupShortView>>> GetAllGroupAsync();
        public Task<GroupShortView> GetGroupByIdAsync(string id);
        #endregion

        #region Detail View
        public Task<ActionResult<List<GroupDetailView>>> GetAllGroupDetailAsync();
        public Task<GroupDetailView> GetGroupDetailByIdAsync(string id);
        public Task<string> AddGroupAsync(GroupDetailView model);
        public Task UpdateGroupAsync(string id, GroupDetailView model);
        public Task DeleteGrouptAsync(string id);
        #endregion
    }
}
