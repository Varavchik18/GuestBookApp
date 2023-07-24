using AutoMapper;
using Domain.Models;

public class GetNotesMapper:Profile
{
    public GetNotesMapper()
    {
        CreateMap<Note,GetNotesResponse>();
    }
}