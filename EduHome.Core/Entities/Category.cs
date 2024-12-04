using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class Category : BaseEntity
{
    public List<CategoryDetail> CategoryDetails { get; set; } = [];
}
