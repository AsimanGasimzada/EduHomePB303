using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DataAccess.DataInitalizers;

public static class SeedDataService
{
    public static void AddSeedData(this ModelBuilder modelBuilder)
    {
        AddLanguages(modelBuilder);
    }

    private static void AddLanguages(ModelBuilder modelBuilder)
    {
        Language language1 = new()
        {
            Id = 1,
            Name = "AZE",
            IsoCode = "az",
            IsDeleted = false,
            CreatedBy = "Admin",
            UpdatedBy = "Admin",
            CreatedTime = DateTime.MinValue,
            UpdatedTime = DateTime.MinValue,
            ImagePath = ""

        };


        Language language2 = new()
        {
            Id = 2,
            Name = "ENG",
            IsoCode = "en",
            IsDeleted = false,
            CreatedBy = "Admin",
            UpdatedBy = "Admin",
            CreatedTime = DateTime.MinValue,
            UpdatedTime = DateTime.MinValue,
            ImagePath = ""

        };



        Language language3 = new()
        {
            Id = 3,
            Name = "RUS",
            IsoCode = "ru",
            IsDeleted = false,
            CreatedBy = "Admin",
            UpdatedBy = "Admin",
            CreatedTime = DateTime.MinValue,
            UpdatedTime = DateTime.MinValue,
            ImagePath = ""

        };

        modelBuilder.Entity<Language>().HasData(language1, language2, language3);
    }
}
