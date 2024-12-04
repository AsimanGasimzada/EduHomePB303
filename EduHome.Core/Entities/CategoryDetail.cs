using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class CategoryDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public Language Language { get; set; } = null!;
    public int LanguageId { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
