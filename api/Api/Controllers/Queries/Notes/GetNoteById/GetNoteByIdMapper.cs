using AutoMapper;
using Domain.Models;
namespace Api.Controllers.Queries.Notes;
public class GetNoteByIdMapper : Profile
{
    public GetNoteByIdMapper()
    {
        CreateMap<Note, GetNoteByIdResponse>();
    }
}