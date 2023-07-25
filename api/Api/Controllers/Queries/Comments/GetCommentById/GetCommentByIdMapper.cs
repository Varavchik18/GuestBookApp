using AutoMapper;
using Domain.Models;
namespace Api.Controllers.Queries.Comments;
public class GetCommentByIdMapper : Profile
{
    public GetCommentByIdMapper()
    {
        CreateMap<Comment, GetCommentByIdResponse>();
    }
}