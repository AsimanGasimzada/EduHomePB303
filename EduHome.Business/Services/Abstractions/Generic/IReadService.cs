using EduHome.Business.Abstractions.Dto;
using EduHome.Business.Dtos;
using EduHome.Core.Enums;

namespace EduHome.Business.Services.Abstractions.Generic;

public interface IReadService<TGetDto> where TGetDto : IDto
{
    Task<List<CourseGetDto>> GetAllAsync();
    Task<CourseGetDto> GetAsync(int id);
}
