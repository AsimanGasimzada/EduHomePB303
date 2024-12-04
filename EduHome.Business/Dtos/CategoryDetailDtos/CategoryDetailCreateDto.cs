using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CategoryDetailCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public int LanguageId { get; set; }
}
