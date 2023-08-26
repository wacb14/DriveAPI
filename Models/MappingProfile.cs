using AutoMapper;
using DriveAPI.ViewModels;

namespace DriveAPI.Models
{
    public class MappingProfile : Profile
    {
        private string GetName(string name)
        {
            return Path.GetFileNameWithoutExtension(name);
        }
        private string GetExtension(string name)
        {
            return Path.GetExtension(name);
        }
        public MappingProfile()
        {
            CreateMap<Filew, CFile>();
            CreateMap<CFile, Filew>();
            CreateMap<PFile, Filew>()
            .ForMember(dest => dest.name, act => act.MapFrom(src => GetName(src.file.FileName)))
            .ForMember(dest => dest.extension, act => act.MapFrom(src => GetExtension(src.file.FileName)));
        }
    }
}