using EduHome.Business.Abstractions.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EduHome.Business.Services.Abstractions.Generic;

public interface IModifyService<TCreateDto, TUpdateDto>
    where TCreateDto : IDto
    where TUpdateDto : IDto
{
    Task<bool> CreateAsync(TCreateDto dto, ModelStateDictionary modelState);
    Task<bool> UpdateAsync(TUpdateDto dto, ModelStateDictionary modelState);
    Task DeleteAsync(int id);
    Task<TUpdateDto> GetUpdatedDtoAsync(int id);

}