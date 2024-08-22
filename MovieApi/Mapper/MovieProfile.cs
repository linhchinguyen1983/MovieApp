using AutoMapper;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Mapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movies, UploadMovieRequestDto>().ReverseMap();
            CreateMap<Movies, MovieDto>().ReverseMap();
            CreateMap<Movies, UpdateMovieDto>().ReverseMap();
        }
    }
}
