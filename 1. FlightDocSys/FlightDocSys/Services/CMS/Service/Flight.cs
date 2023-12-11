using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class Flight : IFlight
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public Flight(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<List<FlightView>>> getAllFlightListAsync()
        {
            var Flight = await _context.Flights
                .Include(f => f.Documents)
                .Include(f => f.Route)
                .Include(f => f.UserFlights)
                .ThenInclude(f => f.User)
                .ToListAsync();
            return _mapper.Map<List<FlightView>>(Flight);
        }
    }
}
