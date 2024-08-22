using AutoMapper;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            //mapper Object User to RequestRegisterDto and reverse
            CreateMap<User, RequestRegisterDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
