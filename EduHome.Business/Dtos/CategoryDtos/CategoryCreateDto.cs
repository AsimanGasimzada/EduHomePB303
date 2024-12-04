using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CategoryCreateDto : IDto
{
    public List<CategoryDetailCreateDto> CategoryDetails { get; set; } = [];
}
