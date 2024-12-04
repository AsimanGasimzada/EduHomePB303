using EduHome.Business.Abstractions.Dto;
using Microsoft.AspNetCore.Http;

namespace EduHome.Business.Dtos;

public class CourseUpdateDto : IDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public IFormFile? MainImage { get; set; }
    public string? MainImagePath { get; set; }
    public string? HoverImagePath { get; set; }
    public IFormFile? HoverImage { get; set; }
    public List<IFormFile>? Images { get; set; } = [];
    public List<CourseDetailUpdateDto> CourseDetails { get; set; } = [];
    public List<CategoryGetDto>? Categories { get; set; } = [];
    public List<string>? ImagePaths { get; set; } = [];
    public List<int>? ImageIds { get; set; } = [];
}
