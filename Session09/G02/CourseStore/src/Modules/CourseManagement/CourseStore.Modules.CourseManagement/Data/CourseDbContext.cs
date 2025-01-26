using CourseStore.Modules.CourseManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.Modules.CourseManagement.Data;
internal class CourseDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.HasDefaultSchema("course");
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }
}
