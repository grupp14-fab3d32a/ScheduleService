using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Addedseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-3333-111111111111"), "Intense core workout", "Core Blast" },
                    { new Guid("11111111-1111-5555-3333-111111111111"), "Dance your way to strength and condition", "Zumba" },
                    { new Guid("22222222-2222-2222-3333-222222222222"), null, "Yoga Flow" },
                    { new Guid("22222222-2222-6666-3333-222222222222"), null, "Circle Gym" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-3333-111111111111"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-5555-3333-111111111111"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-3333-222222222222"));

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-6666-3333-222222222222"));
        }
    }
}
