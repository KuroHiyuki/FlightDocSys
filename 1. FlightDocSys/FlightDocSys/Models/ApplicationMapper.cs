using AutoMapper;
using FlightDocSys.Authentication;
using FlightDocSys.Models.Enities;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.Relation;
using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Identity;

namespace FlightDocSys.Models
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper() 
        {
            #region CMS

            #region Category
            CreateMap<Category, CategoryShortView>()
                .ForMember(des => des.CategoryId, act => act.MapFrom(src => src.CategoryId))
                .ForMember(des => des.CategoryName, act => act.MapFrom(src => src.CategoryName))
                .ForMember(des => des.CreatedDate, act => act.MapFrom(src => src.CreateDate))
                .ForMember(des => des.UserId, act => act.MapFrom(src => src.UserId))
                .ForMember(des => des.UserName, act => act.MapFrom(src => src.User!.Name))
                .ForMember(des => des.GroupCount, act => act.MapFrom(src => src.GroupCategories.Count(v => v.CategoryId == src.CategoryId)))
                .ReverseMap();

            CreateMap<Category, CategoryDetailView>().ReverseMap();
               //.ForMember(des => des.CategoryName, act => act.MapFrom(src => src.CategoryName))
               //.ForMember(des => des.CreatedDate, act => act.MapFrom(src => src.CreateDate))
               //.ForMember(des => des.UserId, act => act.MapFrom(src => src.UserId))
               //.ForMember(des => des.Description, act => act.MapFrom(src => src.Description))
               //.ReverseMap()
               //.ForMember(des => des.CategoryName, act => act.MapFrom(src => src.CategoryName))
               //.ForMember(des => des.CreateDate, act => act.MapFrom(src => src.CreatedDate))
               //.ForMember(des => des.UserId, act => act.MapFrom(src => src.UserId))
               //.ForMember(des => des.Description, act => act.MapFrom(src => src.Description));

            #endregion

            #region Document
            CreateMap<Document, DocumentShortView>()
                .ForMember(des => des.DocumentId, act => act.MapFrom(src => src.DocumentId))
                .ForMember(des => des.DocumentName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.FlightId, act => act.MapFrom(src => src.FlightId))
                .ForMember(des => des.FlightName, act => act.MapFrom(src => src.Flight!.FlightName))
                .ForMember(des => des.DepartureDate, act => act.MapFrom(src => src.Flight!.DeparturedDate))
                .ForMember(des => des.CategoryId, act => act.MapFrom(src => src.CategoryId))
                .ForMember(des => des.CategoryName, act => act.MapFrom(src => src.Category!.CategoryName))
                .ForMember(des => des.UserId, act => act.MapFrom(src => src.UserId))
                .ForMember(des => des.UserName, act => act.MapFrom(src => src.User!.Name!.FirstOrDefault()))
                .ForMember(des => des.UpdatedDate, act => act.MapFrom(src => src.UpdatedDate))
                .ReverseMap();

            CreateMap<Document, DocumentDetailView>().ReverseMap();
            #endregion

            #region Flight
            CreateMap<Flight, FlightShortView>()
                .ForMember(des => des.FlightId, act => act.MapFrom(src => src.FlightId))
                .ForMember(des => des.FlightName, act => act.MapFrom(src => src.FlightName))
                .ForMember(des => des.DepartureDate, act => act.MapFrom(src => src.DeparturedDate))
                .ForMember(des => des.RouteId, act => act.MapFrom(src => src.Route!.RouteId))
                .ForMember(des => des.ArrivalDate, act => act.MapFrom(src => src.DeparturedDate.AddHours((float)src.Route!.Duration!)))
                .ForMember(des => des.SendFile, act => act.MapFrom(src => src.Documents!.Count(v => (double)v.Version == 1.0 && v.FlightId == src.FlightId)))
                .ForMember(des => des.ReturnFile, act => act.MapFrom(src => src.Documents!.Count(v => (double)v.Version > 1.0 && v.FlightId == src.FlightId))).ReverseMap();

            CreateMap<Flight, FlightDetailView>().ReverseMap();
                //.ForMember(des => des.FlightId, act => act.MapFrom(src => src.FlightId))
                //.ForMember(des => des.FlightName, act => act.MapFrom(src => src.Name))
                //.ForMember(des => des.DepartureDate, act => act.MapFrom(src => src.DeparturedDate))
                //.ForMember(des => des.RouteId, act => act.MapFrom(src => src.RouteId))
                //.ForMember(des => des.TotalFile, act => act.MapFrom(src => src.Documents!.Count(v => v.FlightId == src.FlightId)))
                //.ForMember(des => des.PoL, act => act.MapFrom(src => src.Route!.PointOfloading))
                //.ForMember(des => des.PoU, act => act.MapFrom(src => src.Route!.PointOfunloading))
                //.ReverseMap();
            #endregion

            #region Group
            CreateMap<Group, GroupShortView>()
                .ForMember(des => des.GroupId, act => act.MapFrom(src => src.GroupId))
                .ForMember(des => des.GroupName, act => act.MapFrom(src => src.GroupName))
                .ForMember(des => des.CreatedDate, act => act.MapFrom(src => src.UserGroups.FirstOrDefault()!.CreateDate))
                .ForMember(des => des.UserId, act => act.MapFrom(src => src.UserGroups.Select(u=> u.UserId).FirstOrDefault()))
                .ForMember(des => des.UserEmail, act => act.MapFrom(src => src.UserGroups.Select(ud => ud.User!.Email).FirstOrDefault()))
                .ReverseMap();

            CreateMap<Group, GroupDetailView>().ReverseMap();
                //.ForMember(des => des.GroupId, act => act.MapFrom(src => src.GroupId))
                //.ForMember(des => des.GroupName, act => act.MapFrom(src => src.Name))
                //.ForMember(des => des.Note, act => act.MapFrom(src => src.Note))
                //.ReverseMap();
            #endregion

            #region IsConfirmed
            CreateMap<IsConfirmed, IsConfirmedView>()
                .ForMember(des => des.DocumentId, act => act.MapFrom(src => src.DocumentId))
                .ForMember(des => des.ConfirmDate, act => act.MapFrom(src => src.UpdatedDate))
                .ForMember(des => des.Signature, act => act.MapFrom(src => src.SnapshotSignature))
                .ReverseMap();
            #endregion

            #region Permission 
            CreateMap<Permission, PermissionView>().ReverseMap();
            //.ForMember(des => des.PermissionId, act => act.MapFrom(src => src.PermissionId))
            //.ForMember(des => des.PermissionName, act => act.MapFrom(src => src.PermissionName))
            //.ReverseMap();
            #endregion

            #region Route 
            CreateMap<Entities.Route, RouteView>().ReverseMap();
            //.ForMember(des => des.RouteId, act => act.MapFrom(src => src.RouteId))
            //.ForMember(des => des.Duration, act => act.MapFrom(src => src.Duration))
            //.ForMember(des => des.PointOfloading, act => act.MapFrom(src => src.PointOfloading))
            //.ForMember(des => des.PointOfunloading, act => act.MapFrom(src => src.PointOfunloading))
            //.ReverseMap();
            #endregion

            #region User
            CreateMap<User, UserView>().ReverseMap();
                //.ForMember(des => des.UserId, act => act.MapFrom(src => src.Id))
                //.ForMember(des => des.Name, act => act.MapFrom(src => src.Name))
                //.ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
                //.ForMember(des => des.IsActived, act => act.MapFrom(src => src.IsActived))
                //.ForMember(des => des.IsAdmin, act => act.MapFrom(src => src.IsAdmin))
                //.ReverseMap();
            #endregion

            #region Setting
            CreateMap<Setting, SettingView>()
                .ForMember(des => des.Theme, act => act.MapFrom(src => src.Theme))
                .ForMember(des => des.Logo, act => act.MapFrom(src => src.NameLogo));
            #endregion

            #endregion

            #region Moblie
            #endregion
        }
    }
}
