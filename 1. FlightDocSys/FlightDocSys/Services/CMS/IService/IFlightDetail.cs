﻿using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IFlightDetail
    {
        public Task<ActionResult<List<FlightDetailView>>> GetAllFlightDetailAsync();
        public Task<FlightDetailView> GetOneFlightDetailAsync(string Name);
        //public Task<int> AddDocumentListAsync(FlightDetailView model);
        //public Task UpdateFlightDetailAsync(string Name, FlightDetailView model);
        //public Task DeleteFlightDetailAsync(string Name);
    }
}
