using AutoMapper;
using Domain.Models;
namespace Api.Controllers.Queries.Comments;

public class GetCommentsMapper : Profile
{
    public GetCommentsMapper()
    {
        CreateMap<Comment, GetCommentsResponse>()
           .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author));

        CreateMap<Author, AuthorInfoDTO>();
    }
}