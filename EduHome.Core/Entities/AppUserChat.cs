using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class AppUserChat : BaseEntity
{
    public int ChatId { get; set; }
    public Chat Chat { get; set; } = null!;
    public string AppUserId { get; set; } = null!;
    public AppUser AppUser { get; set; } = null!;

}