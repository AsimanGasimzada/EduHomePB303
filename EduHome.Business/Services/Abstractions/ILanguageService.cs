using EduHome.Business.Dtos;

namespace EduHome.Business.Services.Abstractions;

public interface ILanguageService
{
    Task<List<LanguageGetDto>> GetAllAsync();
    Task<LanguageGetDto> GetAsync(int id);
    Task<bool> IsExistAsync(int id);
}
