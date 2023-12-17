using AutoMapper;
using FlightDocSys.Models;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class GroupPermissionService : IGroupPermissionService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public GroupPermissionService(FlightDocSysContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<List<GroupShortView>>> GetAllGroupAsync()
        {
            var Document = await _context.Groups
                .Include(document => document.UserGroups)
                .ThenInclude(document => document.User)
                .ToListAsync();
            return _mapper.Map<List<GroupShortView>>(Document);
        }
        public async Task<GroupShortView> GetGroupByIdAsync(string id)
        {
            var Document = await _context.Groups
                .Include(document => document.UserGroups)
                .ThenInclude(document => document.User)
                .FirstOrDefaultAsync(document => document.GroupId == id);
            return _mapper.Map<GroupShortView>(Document);
        }
        public async Task<string> AddGroupAsync(GroupDetailView model)
        {
            var Add = _mapper.Map<Group>(model);
            await _context.Groups!.AddAsync(Add);
            await _context.SaveChangesAsync();
            return Add.GroupId!;
        }
        public async Task DeleteGrouptAsync(string id)
        {
            var delete = await _context.Groups.SingleOrDefaultAsync(b => b.GroupId == id);
            if (delete != null)
            {
                _context.Groups.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ActionResult<List<GroupDetailView>>> GetAllGroupDetailAsync()
        {
            var Document = await _context.Groups
                .ToListAsync();
            return _mapper.Map<List<GroupDetailView>>(Document);
        }
        public async Task<GroupDetailView> GetGroupDetailByIdAsync(string id)
        {
            var Document = await _context.Groups
                .FirstOrDefaultAsync(document => document.GroupId == id);
            return _mapper.Map<GroupDetailView>(Document);
        }
        public async Task UpdateGroupAsync(string id, GroupDetailView model)
        {
                var update = _mapper.Map<Group>(model);
                _context.Groups.Update(update);
                await _context.SaveChangesAsync();
        }
    }
}
