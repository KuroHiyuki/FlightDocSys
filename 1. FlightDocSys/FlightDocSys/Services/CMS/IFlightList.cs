using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS
{
    public interface IFlightList
    {
        public Task<ActionResult<List<FlightListView>>> getAllFlightListAsync();
    }
}
