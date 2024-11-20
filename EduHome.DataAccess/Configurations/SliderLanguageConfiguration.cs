using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHome.DataAccess.Configurations;

internal class SliderLanguageConfiguration : IEntityTypeConfiguration<SliderLanguage>
{
    public void Configure(EntityTypeBuilder<SliderLanguage> builder)
    {
        builder.HasIndex(x => new { x.SliderId, x.LanguageId }).IsUnique();

        builder.Property(x=>x.Title).IsRequired().HasMaxLength(64);
        builder.Property(x=>x.Subtitle).IsRequired().HasMaxLength(256);
        builder.Property(x=>x.ButtonTitle).IsRequired().HasMaxLength(64);
    }
}
