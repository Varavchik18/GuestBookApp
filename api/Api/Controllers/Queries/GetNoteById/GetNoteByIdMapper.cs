using AutoMapper;
using Domain.Models;

public class GetNoteByIdMapper : Profile
{
    public GetNoteByIdMapper()
    {
        CreateMap<Note, GetNoteByIdResponse>();
    }
}