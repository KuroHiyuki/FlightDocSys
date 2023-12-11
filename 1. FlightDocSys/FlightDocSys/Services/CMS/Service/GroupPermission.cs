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
    public class GroupPermission : IGroupPermission
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;
        //private readonly UserManager<User> _userManager;

        public GroupPermission(FlightDocSysContext context, IMapper mapper) //UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            //_userManager = userManager;
        }
        //public async Task<string> AddGroupPerissionListAsync(GroupPermissionView model)
        //{
        //    /*var document = _context.Groups.FirstAsync();
        //    var group = new Group
        //    {
        //        GroupId = document.Group,
        //        Name = model.GroupName,
        //        Note = model.Note,
        //    };
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return "Không tìm thấy người dùng!";
        //    }
        //    var userGroup = new UserGroup
        //    {
        //        GroupId = group.GroupId, 
        //        UserId = model.UserId,
        //        CreateDate = DateTime.Now
        //    };
        //    _context.UserGroups.Add(userGroup);
        //    await _context.SaveChangesAsync();*/
        //    return "Thêm dữ liệu thành công!";
        //}
        public async Task DeleteGroupPermissionListAsync(string Name)
        {
            var delete = await _context.Groups.SingleOrDefaultAsync(b => b.Name == Name);
            if (delete != null)
            {
                var related = _context.UserGroups.Where(ud => ud.GroupId == delete.GroupId);
                _context.UserGroups.RemoveRange(related);
                _context.Groups.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<List<GroupPermissionView>>> GetAllGroupPermisionListAsync()
        {
            var groups = await _context.Groups
                .Include(dt => dt.UserGroups)
                .ThenInclude(dt => dt.User)
                .ToListAsync();
            return _mapper.Map<List<GroupPermissionView>>(groups!);
        }

        public async Task<GroupPermissionView> GetOneGroupPermissionViewAsync(string Name)
        {
            var groups = await _context.Groups
                .Include(dt => dt.UserGroups)
                .FirstOrDefaultAsync(dt => dt.Name == Name);
            return _mapper.Map<GroupPermissionView>(groups!);
        }

        public async Task UpdateGroupPermissionListAsync(string Name, GroupPermissionView model)
        {
            if (Name == model.GroupName)
            {
                var updateGroupPermission = _mapper.Map<Group>(model);
                /*var relatedEntity = _context.UserGroups.FirstOrDefault(ug => ug.GroupId == updateGroupPermission.GroupId);
                if (relatedEntity != null)
                {
                    relatedEntity.CreateDate = model.CreatedDate;
                    _context.UserGroups.Update(relatedEntity);
                    
                }*/
                _context.Groups.Update(updateGroupPermission);
                await _context.SaveChangesAsync();
            }
        }
    }
}
