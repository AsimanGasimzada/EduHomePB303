using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class Course : BaseEntity
{
    public int Rating { get; set; }=0;
    public Category Category { get; set; } = null!;
    public int CategoryId { get; set; }
    public List<CourseDetail> CourseDetails { get; set; } = [];
    public List<CourseImage> CourseImages { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
}
