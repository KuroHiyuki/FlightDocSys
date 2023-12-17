using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IFlightService
    {
        #region Short View
        public Task<ActionResult<List<FlightShortView>>> GetAllFlightAsync();
        public Task<FlightShortView> GetFlightByIdAsync(string id);
        #endregion

        #region Detail View
        public Task<ActionResult<List<FlightDetailView>>> GetAllFlightDetailAsync();
        public Task<FlightDetailView> GetFlightDetailByIdAsync(string id);
        public Task<string> AddFlightAsync(FlightDetailView model);
        public Task UpdateFlightAsync(string id, FlightDetailView model);
        public Task DeleteFlightAsync(string id);
        #endregion
    }
}
