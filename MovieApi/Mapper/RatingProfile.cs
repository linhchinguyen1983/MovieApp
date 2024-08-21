using AutoMapper;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Mapper
{
    public class RatingProfile : Profile
    {
        public RatingProfile() 
        {
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Rating, AddRatingDto>().ReverseMap();    
        
        }

    }
}
