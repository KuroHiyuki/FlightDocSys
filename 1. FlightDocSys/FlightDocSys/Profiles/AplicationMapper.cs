using AutoMapper;
using FlightDocSys.Models;
using FlightDocSys.Profiles.DTOModels;

namespace FlightDocSys.Profiles
{
    public class AplicationMapper : Profile
    {
        public AplicationMapper() 
        {
            CreateMap<Document, DocumentDTO>().ReverseMap();
        }
    }
}
