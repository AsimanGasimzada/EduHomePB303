using EduHome.Business.Dtos;
using EduHome.Business.Services.Abstractions.Generic;

namespace EduHome.Business.Services.Abstractions;

public interface ICourseService : IReadWithLanguageService<CourseGetDto>, IModifyService<CourseCreateDto, CourseUpdateDto>
{
    Task<CourseCreateDto> GetCreatedDtoAsync();
    Task DeleteImageAsync(int id);
    Task<CourseCreateDto> GetCreatedDtoAsync(CourseCreateDto dto);
    Task<CourseUpdateDto> GetUpdatedDtoAsync(CourseUpdateDto dto);


    //generic service e köçürüldü
    //Task<List<CourseGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan);
    //Task<CourseGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan);
    //Task<bool> CreateAsync(CourseCreateDto dto, ModelStateDictionary modelState);
    //Task DeleteAsync(int id);
    //Task<bool> UpdateAsync(CourseUpdateDto dto, ModelStateDictionary modelState);
    //Task<CourseUpdateDto> GetUpdatedDtoAsync(int id);
}
