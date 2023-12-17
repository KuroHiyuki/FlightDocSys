using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Enities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class IsConfirmService : IIsConfirmedService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public IsConfirmService(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<List<IsConfirmedView>>> GetAllIsConfirmAsync()
        {
            var Document = await _context.IsConfirmeds
                .ToListAsync();
            return _mapper.Map<List<IsConfirmedView>>(Document);
        }

        public async Task<IsConfirmedView> GetIsConfirmByIdAsync(string id)
        {
            var Document = await _context.IsConfirmeds
                .FirstOrDefaultAsync(document => document.DocumentId == id);
            return _mapper.Map<IsConfirmedView>(Document);
        }

        public async Task<string> IsConfirmAsync(IsConfirmedView model)
        {
            var Add = _mapper.Map<IsConfirmed>(model);
            await _context.IsConfirmeds!.AddAsync(Add);
            await _context.SaveChangesAsync();
            return Add.DocumentId!;
        }
    }
}
