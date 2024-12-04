using AutoMapper;
using EduHome.Business.Dtos;
using EduHome.Core.Entities;

namespace EduHome.Business.AutoMappers;

internal class CategoryDetailAutoMapper : Profile
{
    public CategoryDetailAutoMapper()
    {
        CreateMap<CategoryDetail, CategoryDetailCreateDto>().ReverseMap();
        CreateMap<CategoryDetail, CategoryDetailUpdateDto>().ReverseMap();
    }
}