using EduHome.Business.Abstractions.Dto;
using EduHome.Core.Enums;

namespace EduHome.Business.Services.Abstractions.Generic;

public interface IReadWithLanguageService<TGetDto> where TGetDto : IDto
{
    Task<List<TGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan);
    Task<TGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan);
}