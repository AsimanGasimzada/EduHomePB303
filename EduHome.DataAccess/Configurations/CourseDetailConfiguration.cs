using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHome.DataAccess.Configurations;

internal class CourseDetailConfiguration : IEntityTypeConfiguration<CourseDetail>
{
    public void Configure(EntityTypeBuilder<CourseDetail> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(256);

        builder.HasIndex(x => new { x.CourseId, x.LanguageId }).IsUnique();
    }
}
