using AutoMapper;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.Relation;
using FlightDocSys.Models.View;

namespace FlightDocSys.Models
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper() 
        {
            #region DocumentListView
            CreateMap<Document, DocumentListView>()
                .ForMember(des => des.DocumentName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.FlightName, act => act.MapFrom(src => src.Flight!.Name))
                .ForMember(des => des.DepartureDate, act => act.MapFrom(src => src.Flight!.DepartureDate))
                .ForMember(des => des.CreateDate, act => act.MapFrom(src => src.CreateDate))
                .ForMember(des => des.UserName, act => act.MapFrom(src => src.UserDocuments.Select(ud => ud.User!.Name).FirstOrDefault()));
            #endregion
            #region FlightListView
            CreateMap<Flight,FlightListView>()
                .ForMember(des => des.FlightId, act => act.MapFrom(src => src.FlightId))
                .ForMember(des => des.FlightName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.DepartureDate, act => act.MapFrom(src => src.DepartureDate))
                .ForMember(des => des.ArrivalDate, act => act.MapFrom(src => src.DepartureDate.AddHours((double)src.Route!.Duration!)))
                .ForMember(des => des.SendFile, act => act.MapFrom(src => src.Documents.Count(v => (double)v.Version == 1.0)))
                .ForMember(des => des.ReturnFile, act => act.MapFrom(src => src.Documents.Count(v => (double)v.Version > 1.0)));
            #endregion
            #region DocumentTypeListView
            CreateMap<Document_Type,DocumentTypeListView>()
                .ForMember(des => des.Document_TypeId, act => act.MapFrom(src => src.Document_TypeId))
                .ForMember(des => des.Document_TypeName, act => act.MapFrom(src => src.Name))
                .ForMember(des => des.Username, act => act.MapFrom(src => src.User!.Name))
                .ForMember(des => des.Despcription, act => act.MapFrom(src => src.Description))
                .ForMember(des => des.GroupName, act => act.MapFrom(src => src.GroupDocumenttypes.Select(g =>g.Group!.Name).FirstOrDefault()))
                .ForMember(des => des.CountPermission, act => act.MapFrom(src => src.GroupDocumenttypes.Count(v => v.Document_TypeId==src.Document_TypeId)));
            #endregion
        }
    }
}
