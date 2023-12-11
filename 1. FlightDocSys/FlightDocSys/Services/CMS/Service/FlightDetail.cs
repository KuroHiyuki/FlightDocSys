using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class FlightDetail : IFlightDetail
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public FlightDetail(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public Task DeleteFlightDetailAsync(string Name)
        //{
        //    throw new NotImplementedException();
        //}

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

        //public Task UpdateFlightDetailAsync(string Name, FlightDetailView model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
