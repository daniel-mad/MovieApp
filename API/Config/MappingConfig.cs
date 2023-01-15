
using AutoMapper;
using Entities.Models;
using Shared.DTOs;

namespace API.Config;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<MostPopularDataDetail, MovieDto>()
            .ForMember(m => m.Description, opt => opt.MapFrom(mp => mp.FullTitle));
        CreateMap<Movie, MovieDto>().ReverseMap();

    }
}
