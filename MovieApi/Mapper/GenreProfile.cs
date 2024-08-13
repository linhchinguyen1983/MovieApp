using AutoMapper;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Mapper
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genres, GenreDto>().ReverseMap();
            CreateMap<Genres, AddGenreRequestDto>().ReverseMap();
        }
    }
}
