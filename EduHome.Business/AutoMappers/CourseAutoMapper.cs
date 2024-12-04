using AutoMapper;
using EduHome.Business.Dtos;
using EduHome.Core.Entities;

namespace EduHome.Business.AutoMappers;

internal class CourseAutoMapper : Profile
{
    public CourseAutoMapper()
    {
        CreateMap<Course, CourseCreateDto>().ReverseMap();
        CreateMap<Course, CourseUpdateDto>()
            .ForMember(x => x.ImagePaths, x => x.MapFrom(x => x.CourseImages.Where(x => !x.IsMain && !x.IsHover).Select(x => x.Path).ToList()))
            .ForMember(x => x.ImageIds, x => x.MapFrom(x => x.CourseImages.Where(x => !x.IsMain && !x.IsHover).Select(x => x.Id).ToList()))
            .ForMember(x => x.MainImagePath, x => x.MapFrom(x => x.CourseImages.FirstOrDefault(x => x.IsMain) != null ? x.CourseImages.FirstOrDefault(x => x.IsMain)!.Path : string.Empty))
            .ForMember(x => x.HoverImagePath, x => x.MapFrom(x => x.CourseImages.FirstOrDefault(x => x.IsHover) != null ? x.CourseImages.FirstOrDefault(x => x.IsHover)!.Path : string.Empty))
            .ReverseMap();


        CreateMap<Course, CourseGetDto>()
            .ForMember(x => x.Name, x => x.MapFrom(x => x.CourseDetails.FirstOrDefault() != null ? x.CourseDetails.FirstOrDefault()!.Name : string.Empty))
            .ForMember(x => x.Description, x => x.MapFrom(x => x.CourseDetails.FirstOrDefault() != null ? x.CourseDetails.FirstOrDefault()!.Description : string.Empty))
            .ForMember(x => x.ImagePaths, x => x.MapFrom(x => x.CourseImages.Where(x => !x.IsMain && !x.IsHover).Select(x => x.Path).ToList()))
            .ForMember(x => x.MainImagePath, x => x.MapFrom(x => x.CourseImages.FirstOrDefault(x => x.IsMain) != null ? x.CourseImages.FirstOrDefault(x => x.IsMain)!.Path : string.Empty))
            .ForMember(x => x.HoverImagePath, x => x.MapFrom(x => x.CourseImages.FirstOrDefault(x => x.IsHover) != null ? x.CourseImages.FirstOrDefault(x => x.IsHover)!.Path : string.Empty))
            .ReverseMap();
    }
}
