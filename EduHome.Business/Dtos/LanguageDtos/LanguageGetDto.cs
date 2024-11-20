using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class LanguageGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string IsoCode { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
