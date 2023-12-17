using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
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
        public async Task<ActionResult<List<FlightShortView>>> GetAllFlightAsync()
        {
            var Document = await _context.Flights
                .Include(document => document.Route)
                .Include(document => document.Documents)
                .ToListAsync();
            return _mapper.Map<List<FlightShortView>>(Document);
        }
        public async Task<FlightShortView> GetFlightByIdAsync(string id)
        {
            var Document = await _context.Flights
                .Include(document => document.Route)
                .Include(document => document.Documents)
                .FirstOrDefaultAsync(document => document.FlightId == id);
            return _mapper.Map<FlightShortView>(Document);
        }
        public async Task<string> AddFlightAsync(FlightDetailView model)
        {
            var AddFlight = _mapper.Map<Flight>(model);
            await _context.Flights!.AddAsync(AddFlight);
            await _context.SaveChangesAsync();
            return AddFlight.FlightId!;
        }

        public async Task DeleteFlightAsync(string id)
        {
            var deleteFlight = await _context.Flights.SingleOrDefaultAsync(b => b.FlightId == id);
            if (deleteFlight != null)
            {
                _context.Flights.Remove(deleteFlight);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ActionResult<List<FlightDetailView>>> GetAllFlightDetailAsync()
        {
            var Document = await _context.Flights
                .ToListAsync();
            return _mapper.Map<List<FlightDetailView>>(Document);
        }
        public async Task<FlightDetailView> GetFlightDetailByIdAsync(string id)
        {
            var Document = await _context.Flights
                .FirstOrDefaultAsync(document => document.FlightId == id);
            return _mapper.Map<FlightDetailView>(Document);
        }

        public async Task UpdateFlightAsync(string id, FlightDetailView model)
        {
            var checkId = await _context.Categorys.FindAsync(id);
            if (checkId != null)
            {
                var updateFlight = _mapper.Map<Flight>(model);
                _context.Flights.Update(updateFlight);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
