using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CategoryGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}