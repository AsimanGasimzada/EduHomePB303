using EduHome.Business.Dtos;
using EduHome.Business.Services.Abstractions.Generic;

namespace EduHome.Business.Services.Abstractions;

public interface ICategoryService : IReadWithLanguageService<CategoryGetDto>, IModifyService<CategoryCreateDto, CategoryUpdateDto>
{
    Task<bool> IsExistAsync(int id);

    //generic service e köçürüldü
    //Task<List<CategoryGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan);
    //Task<CategoryGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan);
    //Task<bool> CreateAsync(CategoryCreateDto dto, ModelStateDictionary modelState);
    //Task DeleteAsync(int id);
    //Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary modelState);
    //Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id);
}
