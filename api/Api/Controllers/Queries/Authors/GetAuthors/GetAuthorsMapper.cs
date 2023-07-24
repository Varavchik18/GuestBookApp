using AutoMapper;
using Domain.Models;
namespace Api.Controllers.Queries.Authors;
public class GetAuthorsMapper : Profile
{
    public GetAuthorsMapper()
    {
        CreateMap<Author, GetAuthorsResponse>();
    }
}