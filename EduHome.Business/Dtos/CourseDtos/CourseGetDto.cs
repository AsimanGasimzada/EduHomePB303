using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CourseGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; }
    public CategoryGetDto? Category { get; set; }
    public List<string> ImagePaths { get; set; } = null!;
    public string MainImagePath { get; set; } = null!;
    public string HoverImagePath { get; set; } = null!;
}