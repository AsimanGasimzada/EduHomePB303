using EduHome.Business.Abstractions.Dto;

namespace EduHome.Business.Dtos;

public class CommentReplyDto:IDto
{
    public int ParentId { get; set; }
    public int CourseId { get; set; }

    public string Text { get; set; }
}
