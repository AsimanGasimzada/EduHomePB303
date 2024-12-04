using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CourseDetailCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LanguageId { get; set; }

}
