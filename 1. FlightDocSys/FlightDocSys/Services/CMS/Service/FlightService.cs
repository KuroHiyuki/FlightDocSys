using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class FlightService : IFlightService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public FlightService(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<List<FlightView>>> getAllFlightListAsync()
        {
            var Flight = await _context.Flights
                .Include(f => f.Documents)
                .Include(f => f.Route)
                .ToListAsync();
            return _mapper.Map<List<FlightView>>(Flight);
        }
        public async Task<ActionResult<List<FlightDetailView>>> GetAllFlightDetailAsync()
        {
            var Document = await _context.Flights
                .Include(dt => dt.Route)
                .ToListAsync();
            return _mapper.Map<List<FlightDetailView>>(Document!);
        }

        public async Task<FlightDetailView> GetOneFlightDetailAsync(string Name)
        {
            var Document = await _context.Flights
                .Include(dt => dt.Route)
                .FirstOrDefaultAsync(document => document.Name == Name);
            return _mapper.Map<FlightDetailView>(Document!);
        }
    }
}
