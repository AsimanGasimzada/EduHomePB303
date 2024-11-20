using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class Language : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string IsoCode { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
