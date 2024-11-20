using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class Slider : BaseEntity
{
    public string ImagePath { get; set; } = null!;

    public ICollection<SliderLanguage> SliderLanguages { get; set; } = [];

}
