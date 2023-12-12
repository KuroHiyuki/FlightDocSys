using AutoMapper;
using FlightDocSys.Authentication;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.Relation;
using FlightDocSys.Models.View;

namespace FlightDocSys.Models
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper() 
        {
            #region CMS
            #region DocumentView
            CreateMap<Document, DocumentView>()
                .ForMember(des => des.DocumentName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.FlightName, act => act.MapFrom(src => src.Flight!.Name))
                .ForMember(des => des.DepartureDate, act => act.MapFrom(src => src.Flight!.DeparturedDate))
                .ForMember(des => des.CreateDate, act => act.MapFrom(src => src.UpdatedDate))
                .ForMember(des => des.DocumentTypeName, act => act.MapFrom(src => src.Category!.Name))
                .ForMember(des => des.UserName, act => act.MapFrom(src => src.User!.Name!.FirstOrDefault()));
            #endregion

            #region DocumentDetail
            CreateMap<Document, DocumentDetailView>()
                .ForMember(des => des.DocumentName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.DocumentTypeName, act => act.MapFrom(src => src.Category!.Name))
                .ForMember(des => des.Note, act => act.MapFrom(src => src.Note))
                .ForMember(des => des.UserName, act => act.MapFrom(src => src.User!.Name!.FirstOrDefault()))
                .ForMember(des => des.Version, act => act.MapFrom(src => src.Version));
            #endregion

            #region FlightView
            CreateMap<Flight,FlightView>()
                .ForMember(des => des.FlightName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.DepartureDate, act => act.MapFrom(src => src.DeparturedDate))
                .ForMember(des => des.ArrivalDate, act => act.MapFrom(src => src.DeparturedDate.AddHours((double)src.Route!.Duration!)))
                .ForMember(des => des.SendFile, act => act.MapFrom(src => src.Documents!.Count(v => (double)v.Version == 1.0)))
                .ForMember(des => des.ReturnFile, act => act.MapFrom(src => src.Documents!.Count(v => (double)v.Version > 1.0)));
            #endregion

            #region FlightDetailView
            CreateMap<Flight, FlightDetailView>()
                .ForMember(des => des.FlightName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.DepartureDate, act => act.MapFrom(src => src.DeparturedDate))
                .ForMember(des => des.POL, act => act.MapFrom(src => src.Route!.PointOfloading))
                .ForMember(des => des.POU, act => act.MapFrom(src => src.Route!.PointOfunloading));
            #endregion

            #region DocumentTypeView
            CreateMap<Category,DocumentTypeView>()
                .ForMember(des => des.Document_TypeId, act => act.MapFrom(src => src.CategoryId))
                .ForMember(des => des.Document_TypeName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.Username, act => act.MapFrom(src => src.User!.Name))
                .ForMember(des => des.Despcription, act => act.MapFrom(src => src.Description))
                .ForMember(des => des.GroupName, act => act.MapFrom(src => src.GroupCategories.Select(g =>g.Group!.Name).FirstOrDefault()))
                .ForMember(des => des.CountPermission, act => act.MapFrom(src => src.GroupCategories.Count(v => v.CategoryId==src.CategoryId)));
            #endregion

            #region SettingView
            CreateMap<Setting, SettingView>()
                .ForMember(des => des.Theme, act => act.MapFrom(src => src.Theme))
                .ForMember(des => des.Logo, act => act.MapFrom(src => src.NameLogo));
            #endregion

            #region GroupPermissionView
            CreateMap<Group, GroupPermissionView>()
                .ForMember(des => des.GroupName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.Member, act => act.MapFrom(src => src.UserGroups.Count(c => c.GroupId == src.GroupId)))
                .ForMember(des => des.CreatedDate, act => act.MapFrom(src => src.UserGroups.FirstOrDefault()!.CreateDate))
                .ForMember(des => des.Note, act => act.MapFrom(src => src.Note))
                .ForMember(des => des.UserName, act => act.MapFrom(src => src.UserGroups.Select(ud => ud.User!.Email).FirstOrDefault()));
            #endregion

            //#region Account
            //CreateMap<User, SignUp>()
            //    .ForMember(des => des.Name, act => act.MapFrom(src => src.Name))
            //    .ForMember(des => des.NumberPhone, act => act.MapFrom(src => src.NumberPhone))
            //    .ForMember(des => des.Password, act => act.MapFrom(src => src.Password))
            //    .ForMember(des => des.Email, act => act.MapFrom(src => src.Email));
            //CreateMap<User, SignIn>()
            //    .ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
            //    .ForMember(des => des.Password, act => act.MapFrom(src => src.Password));
            //#endregion

            #endregion

            #region Moblie
            #endregion
        }
    }
}
