using AutoMapper;
using DriveAPI.ViewModels;

namespace DriveAPI.Models
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