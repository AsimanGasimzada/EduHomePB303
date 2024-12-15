using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class ConnectionDto : IDto
{
    public string UserId { get; set; } = null!;
    public List<string> ConnectionIds { get; set; } = [];
}
