using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IUserService
    {
        public Task<ActionResult<List<UserView>>> GetAllUserAsync();
        public Task<UserView> GetUserByIdAsync(string id);
        public Task<UserView> GetUserByEmailAsync(string email);
        public Task UpdateUserAsync(string id, UserView model);
        public Task DeleteUserAsync(string id);
    }
}
