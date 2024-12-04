using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class CourseDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Course Course { get; set; } = null!;
    public Language Language { get; set; } = null!;
    public int LanguageId { get; set; }
    public int CourseId { get; set; }

}