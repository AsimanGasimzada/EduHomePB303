using EduHome.Core.Entities;
using EduHome.DataAccess.DataInitalizers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EduHome.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.AddSeedData();
        modelBuilder.Entity<Language>().HasQueryFilter(x => !x.IsDeleted);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<SliderLanguage> SliderLanguages { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<CategoryDetail> CategoryDetails { get; set; } = null!;
    public DbSet<Course> Courses { get; set; }=null!;
    public DbSet<CourseDetail> CourseDetails { get; set; } = null!;
    public DbSet<CourseImage> CourseImages { get; set; } = null!;

}
