using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzureWebApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Date);
                });

            migrationBuilder.InsertData(
                table: "Weathers",
                columns: new[] { "Date", "Id", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new DateOnly(2024, 1, 1), 0, "Cool", 15 },
                    { new DateOnly(2024, 1, 2), 0, "Warm", 22 },
                    { new DateOnly(2024, 1, 3), 0, "Freezing", -5 },
                    { new DateOnly(2024, 1, 4), 0, "Hot", 30 },
                    { new DateOnly(2024, 1, 5), 0, "Mild", 18 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
