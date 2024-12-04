using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CategoryUpdateDto : IDto
{
    public int Id { get; set; }
    public List<CategoryDetailUpdateDto> CategoryDetails { get; set; } = [];
}
