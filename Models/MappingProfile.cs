using AutoMapper;
using DriveAPI.Models;
using DriveAPI.ViewModels;

namespace Backend.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Filew, CFile>();
            CreateMap<CFile, Filew>();
        }
    }
}