using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CommentCreateDto : IDto
{
    public string Text { get; set; }
    public int Rating { get; set; }
    public int CourseId { get; set; }
}
