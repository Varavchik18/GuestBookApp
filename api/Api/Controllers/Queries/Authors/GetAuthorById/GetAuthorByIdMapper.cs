using AutoMapper;
using Domain.Models;

public class GetAuthorByIdMapper : Profile
{
    public GetAuthorByIdMapper()
    {
        CreateMap<Author, GetAuthorByIdResponse>();
    }
}