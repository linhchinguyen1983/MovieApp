using AutoMapper;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Mapper
{
    public class EpisodeProfile :Profile
    {
        public EpisodeProfile() 
        { 
            CreateMap<Episode,EpisodeDto>().ReverseMap();
            CreateMap<Episode,AddEpisodeDto>().ReverseMap();
            CreateMap<Episode,UpdateEpisodeDto>().ReverseMap();
        }

    }
}
