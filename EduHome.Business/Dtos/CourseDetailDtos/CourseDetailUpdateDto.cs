using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CourseDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LanguageId { get; set; }

}
