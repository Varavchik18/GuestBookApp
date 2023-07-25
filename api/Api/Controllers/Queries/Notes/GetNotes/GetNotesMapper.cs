using AutoMapper;
using Domain.Models;
namespace Api.Controllers.Queries.Notes;

public class GetNotesMapper : Profile
{
    public GetNotesMapper()
    {
        CreateMap<Note, GetNotesResponse>()
           .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author));

        CreateMap<Author, AuthorInfoDTO>();
    }
}