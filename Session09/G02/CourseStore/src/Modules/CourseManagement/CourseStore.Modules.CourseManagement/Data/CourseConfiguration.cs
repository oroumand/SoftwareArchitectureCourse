using CourseStore.Modules.CourseManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseStore.Modules.CourseManagement.Data;
internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.Property(c => c.Title).HasMaxLength(100);
        builder.Property(c => c.Teacher).HasMaxLength(100);
        builder.Property(c => c.Description).HasMaxLength(500);

        builder.HasData(
            new Course(1, "Pro ASP.NET Core", "Pro ASP.NET Course Course", "Alireza Oroumand", new DateTime(2025, 5, 5), 10, 1_000_000),
            new Course(2, "Pro EF.NET Core", "Pro EF.NET Course Course", "Alireza Oroumand", new DateTime(2025, 2, 12), 10, 2_000_000),
            new Course(3, "DDD", "DDD", "Alireza Oroumand", new DateTime(2025, 1, 1), 10, 3_000_000),
            new Course(4, "Microservice", "Microservice", "Alireza Oroumand", new DateTime(2025, 2, 1), 10, 4_000_000)
            );
    }
}
