using AutoMapper;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Mapper
{
    public class NewsProfile :Profile
    {
        public NewsProfile() 
        { 
            CreateMap<News, NewsDto>().ReverseMap();
            CreateMap<News, NewsRequestDto>().ReverseMap();
            CreateMap<News, UpdateNewsDto>().ReverseMap();
        }

    }
}
