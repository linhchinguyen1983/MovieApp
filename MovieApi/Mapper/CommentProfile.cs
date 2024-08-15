using AutoMapper;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Mapper
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, PostCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
        }
    }
}
