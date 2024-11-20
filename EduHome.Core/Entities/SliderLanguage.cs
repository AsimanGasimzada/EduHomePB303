using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities;

public class SliderLanguage : BaseEntity
{
    public Slider Slider { get; set; } = null!;
    public int SliderId { get; set; }
    public Language Language { get; set; }=null!;
    public int LanguageId { get; set; }
    public string Title { get; set; } = null!;
    public string Subtitle { get; set; } = null!;
    public string ButtonTitle { get; set; } = null!;

}