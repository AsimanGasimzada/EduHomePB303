using EduHome.Business.Abstractions.Dto;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;

namespace EduHome.Business.Dtos;

public class CourseCreateDto : IDto
{
    public int CategoryId { get; set; }
    public IFormFile MainImage { get; set; } = null!;
    public IFormFile HoverImage { get; set; } = null!;
    public List<IFormFile> Images { get; set; } = [];
    public List<CourseDetailCreateDto> CourseDetails { get; set; } = [];
    public List<CategoryGetDto>? Categories { get; set; } = [];

}
