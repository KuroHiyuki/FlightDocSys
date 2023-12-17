

using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class UserService : IUserService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public UserService(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task DeleteUserAsync(string id)
        {
            var delete = await _context.Users.SingleOrDefaultAsync(b => b.Id == id);
            if (delete != null)
            {
                _context.Users.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<List<UserView>>> GetAllUserAsync()
        {
            var Document = await _context.Users
                 .ToListAsync();
            return _mapper.Map<List<UserView>>(Document);
        }

        public async Task<UserView> GetUserByEmailAsync(string email)
        {
            var Document = await _context.Users
                .FirstOrDefaultAsync(document => document.Email == email);
            return _mapper.Map<UserView>(Document);
        }

        public async Task<UserView> GetUserByIdAsync(string id)
        {
            var Document = await _context.Users
                .FirstOrDefaultAsync(document => document.Id == id);
            return _mapper.Map<UserView>(Document);
        }

        public async Task UpdateUserAsync(string id, UserView model)
        {
            var checkId = await _context.Users.FindAsync(id);
            if (checkId != null)
            {
                var update = _mapper.Map<User>(model);
                _context.Users.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}
