using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChores.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddeddatetimetochoreEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Chores");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Chores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Chores");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "Chores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
