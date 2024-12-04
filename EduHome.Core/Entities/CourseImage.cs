using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class CourseImage : BaseEntity
{
    public string Path { get; set; } = null!;
    public bool IsMain { get; set; } = false;
    public bool IsHover { get; set; } = false;
    public Course Course { get; set; } = null!;
    public int CourseId { get; set; } 

}