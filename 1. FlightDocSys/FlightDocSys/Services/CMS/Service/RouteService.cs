using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class RouteService : IRouteService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public RouteService(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddRouteAsync(RouteView model)
        {
            var Add = _mapper.Map<Models.Entities.Route>(model);
            await _context.Routes!.AddAsync(Add);
            await _context.SaveChangesAsync();
            return Add.RouteId!;
        }

        public async Task DeleteRouteAsync(string id)
        {
            var delete = await _context.Routes.SingleOrDefaultAsync(b => b.RouteId == id);
            if (delete != null)
            {
                _context.Routes.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<List<RouteView>>> GetAllRouteAsync()
        {
            var Document = await _context.Routes
                .ToListAsync();
            return _mapper.Map<List<RouteView>>(Document);
        }

        public async Task<RouteView> GetRouteByIdAsync(string id)
        {
            var Document = await _context.Routes
                .FirstOrDefaultAsync(document => document.RouteId == id);
            return _mapper.Map<RouteView>(Document);
        }

        public async Task UpdateRouteAsync(string id, RouteView model)
        {
            var checkId = await _context.Routes.FindAsync(id);
            if (checkId != null)
            {
                var update = _mapper.Map<Models.Entities.Route>(model);
                _context.Routes.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
