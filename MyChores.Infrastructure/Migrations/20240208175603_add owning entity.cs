using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyChores.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addowningentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Chores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Chores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Chores_UserId",
                table: "Chores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_AspNetUsers_UserId",
                table: "Chores",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chores_AspNetUsers_UserId",
                table: "Chores");

            migrationBuilder.DropIndex(
                name: "IX_Chores_UserId",
                table: "Chores");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Chores");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Chores");
        }
    }
}
