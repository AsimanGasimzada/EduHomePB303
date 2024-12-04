using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHome.DataAccess.Configurations;

internal class CategoryDetailConfiguration : IEntityTypeConfiguration<CategoryDetail>
{
    public void Configure(EntityTypeBuilder<CategoryDetail> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

        builder.HasIndex(x => new { x.LanguageId, x.CategoryId }).IsUnique();
    }
}
