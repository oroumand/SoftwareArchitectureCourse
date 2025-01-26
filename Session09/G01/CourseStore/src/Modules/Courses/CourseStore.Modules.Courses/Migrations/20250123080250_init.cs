using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseStore.Modules.Courses.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "course");

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "course",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Teacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "course",
                table: "Courses",
                columns: new[] { "Id", "Description", "Price", "SessionCount", "StartDate", "Teacher", "Title" },
                values: new object[,]
                {
                    { 1L, "Pro ASP.NET Course Course", 1000000, 10, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alireza Oroumand", "Pro ASP.NET Core" },
                    { 2L, "Pro EF.NET Course Course", 2000000, 10, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alireza Oroumand", "Pro EF.NET Core" },
                    { 3L, "DDD", 3000000, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alireza Oroumand", "DDD" },
                    { 4L, "Microservice", 4000000, 10, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alireza Oroumand", "Microservice" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses",
                schema: "course");
        }
    }
}
