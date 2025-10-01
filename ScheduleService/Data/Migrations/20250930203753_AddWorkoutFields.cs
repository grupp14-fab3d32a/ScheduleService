using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalSpots",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookedSpots",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Workouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Instructor",
                table: "Workouts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Workouts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Workouts",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-3333-111111111111"),
                columns: new[] { "BookedSpots", "Date", "Instructor", "Location", "StartTime", "TotalSpots" },
                values: new object[] { 5, new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Smith", "Room A", new TimeSpan(0, 9, 0, 0, 0), 20 });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-5555-3333-111111111111"),
                columns: new[] { "BookedSpots", "Date", "Instructor", "Location", "StartTime", "TotalSpots" },
                values: new object[] { 0, new DateTime(2025, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carol Davis", "Room C", new TimeSpan(0, 18, 0, 0, 0), 30 });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-3333-222222222222"),
                columns: new[] { "BookedSpots", "Date", "Description", "Instructor", "Location", "StartTime", "TotalSpots" },
                values: new object[] { 3, new DateTime(2025, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Relaxing yoga session", "Bob Johnson", "Room B", new TimeSpan(0, 11, 0, 0, 0), 15 });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-6666-3333-222222222222"),
                columns: new[] { "BookedSpots", "Date", "Description", "Instructor", "Location", "StartTime", "TotalSpots" },
                values: new object[] { 10, new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full body workout", "David Wilson", "Room A", new TimeSpan(0, 17, 0, 0, 0), 25 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Instructor",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Workouts");

            migrationBuilder.AlterColumn<int>(
                name: "TotalSpots",
                table: "Workouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookedSpots",
                table: "Workouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                columns: new[] { "BookedSpots", "Description", "TotalSpots" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-6666-3333-222222222222"),
                columns: new[] { "BookedSpots", "Description", "TotalSpots" },
                values: new object[] { null, null, null });
        }
    }
}
