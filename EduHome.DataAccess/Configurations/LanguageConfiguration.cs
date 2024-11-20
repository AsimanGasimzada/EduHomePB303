using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHome.DataAccess.Configurations;

internal class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
        builder.Property(x => x.IsoCode).IsRequired().HasMaxLength(16);
        builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(256);

        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.IsoCode).IsUnique();
    }
}
