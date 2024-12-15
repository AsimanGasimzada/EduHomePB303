using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class LoginDto:IDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}


public class RegisterDto : IDto
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
