using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IRouteService
    {
        public Task<ActionResult<List<RouteView>>> GetAllRouteAsync();
        public Task<RouteView> GetRouteByIdAsync(string id);
        public Task<string> AddRouteAsync(RouteView model);
        public Task UpdateRouteAsync(string id, RouteView model);
        public Task DeleteRouteAsync(string id);
    }
}
