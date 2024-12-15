using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class Comment : BaseAuditableEntity
{
    public AppUser AppUser { get; set; } = null!;
    public string AppUserId { get; set; } = null!;
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int? Rating { get; set; }
    public int? ParentId { get; set; }
    public Comment? Parent { get; set; } = null!;
    public List<Comment> Children { get; set; } = [];
}
