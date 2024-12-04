using AutoMapper;
using EduHome.Business.Dtos;
using EduHome.Core.Entities;

namespace EduHome.Business.AutoMappers;

internal class CourseDetailAutoMapper : Profile
{
    public CourseDetailAutoMapper()
    {
        CreateMap<CourseDetail, CourseDetailCreateDto>().ReverseMap();
        CreateMap<CourseDetail, CourseDetailUpdateDto>().ReverseMap();
    }
}
