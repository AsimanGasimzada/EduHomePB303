using AutoMapper;
using EduHome.Business.Dtos;
using EduHome.Core.Entities;

namespace EduHome.Business.AutoMappers;

internal class LanguageAutoMapper : Profile
{
    public LanguageAutoMapper()
    {
        CreateMap<Language,LanguageGetDto>();
    }
}


