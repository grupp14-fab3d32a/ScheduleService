using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTotalSpotsandBookedSpots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookedSpots",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalSpots",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-3333-111111111111"),
                columns: new[] { "BookedSpots", "TotalSpots" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-5555-3333-111111111111"),
                columns: new[] { "BookedSpots", "TotalSpots" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-3333-222222222222"),
                columns: new[] { "BookedSpots", "TotalSpots" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-6666-3333-222222222222"),
                columns: new[] { "BookedSpots", "TotalSpots" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedSpots",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "TotalSpots",
                table: "Workouts");
        }
    }
}
