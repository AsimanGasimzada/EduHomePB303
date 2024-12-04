using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CategoryDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int LanguageId { get; set; }
}
