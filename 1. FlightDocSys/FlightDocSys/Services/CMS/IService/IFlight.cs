using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IFlight
    {
        public Task<ActionResult<List<FlightView>>> getAllFlightListAsync();
    }
}
