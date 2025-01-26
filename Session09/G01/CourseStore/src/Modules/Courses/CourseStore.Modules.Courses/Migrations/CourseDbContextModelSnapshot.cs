﻿// <auto-generated />
using System;
using CourseStore.Modules.Courses.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseStore.Modules.Courses.Migrations
{
    [DbContext(typeof(CourseDbContext))]
    partial class CourseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("course")
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseStore.Modules.Courses.Domain.Course", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SessionCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Courses", "course");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Pro ASP.NET Course Course",
                            Price = 1000000,
                            SessionCount = 10,
                            StartDate = new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Teacher = "Alireza Oroumand",
                            Title = "Pro ASP.NET Core"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Pro EF.NET Course Course",
                            Price = 2000000,
                            SessionCount = 10,
                            StartDate = new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Teacher = "Alireza Oroumand",
                            Title = "Pro EF.NET Core"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "DDD",
                            Price = 3000000,
                            SessionCount = 10,
                            StartDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Teacher = "Alireza Oroumand",
                            Title = "DDD"
                        },
                        new
                        {
                            Id = 4L,
                            Description = "Microservice",
                            Price = 4000000,
                            SessionCount = 10,
                            StartDate = new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Teacher = "Alireza Oroumand",
                            Title = "Microservice"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
