using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace FlightDocSys.Services.CMS.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public PermissionService(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddPermissionDetailAsync(PermissionView model)
        {
            var Add = _mapper.Map<Permission>(model);
            await _context.Permissions!.AddAsync(Add);
            await _context.SaveChangesAsync();
            return Add.PermissionId!;
        }

        public async Task DeletePermissionDetailAsync(string id)
        {
            var delete = await _context.Permissions.SingleOrDefaultAsync(b => b.PermissionId == id);
            if (delete != null)
            {
                _context.Permissions.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<List<PermissionView>>> GetAllPermissionDetailAsync()
        {
            var Document = await _context.Permissions
                .ToListAsync();
            return _mapper.Map<List<PermissionView>>(Document);
        }

        public async Task<PermissionView> GetPermissionDetailByIdAsync(string id)
        {
            var Document = await _context.Permissions
                .FirstOrDefaultAsync(document => document.PermissionId == id);
            return _mapper.Map<PermissionView>(Document);
        }

        public async Task UpdatePermissionDetailAsync(string id, PermissionView model)
        {
                var update = _mapper.Map<Permission>(model);
                _context.Permissions.Update(update);
                await _context.SaveChangesAsync();
        }
    }
}
