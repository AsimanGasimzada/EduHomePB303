using EduHome.Core.Entities;
using EduHome.DataAccess.DataInitalizers;
using EduHome.DataAccess.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EduHome.DataAccess.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>
{
    private readonly BaseAuditableInterceptor _interceptor;
    public AppDbContext(DbContextOptions<AppDbContext> options, BaseAuditableInterceptor interceptor) : base(options)
    {
        _interceptor = interceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.AddSeedData();
        modelBuilder.Entity<Language>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Comment>().HasQueryFilter(x => !x.IsDeleted);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<SliderLanguage> SliderLanguages { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<CategoryDetail> CategoryDetails { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<CourseDetail> CourseDetails { get; set; } = null!;
    public DbSet<CourseImage> CourseImages { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Chat> Chats { get; set; } = null!;
    public DbSet<AppUserChat> AppUserChats { get; set; } = null!;

}
