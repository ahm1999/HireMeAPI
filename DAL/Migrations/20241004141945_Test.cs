using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireMeAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Users_UserId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceWorkFields_Experience_ExperienceId",
                table: "ExperienceWorkFields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experience",
                table: "Experience");

            migrationBuilder.RenameTable(
                name: "Experience",
                newName: "Experiences");

            migrationBuilder.RenameIndex(
                name: "IX_Experience_UserId",
                table: "Experiences",
                newName: "IX_Experiences_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Users_UserId",
                table: "Experiences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceWorkFields_Experiences_ExperienceId",
                table: "ExperienceWorkFields",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Users_UserId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceWorkFields_Experiences_ExperienceId",
                table: "ExperienceWorkFields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences");

            migrationBuilder.RenameTable(
                name: "Experiences",
                newName: "Experience");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_UserId",
                table: "Experience",
                newName: "IX_Experience_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experience",
                table: "Experience",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Users_UserId",
                table: "Experience",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceWorkFields_Experience_ExperienceId",
                table: "ExperienceWorkFields",
                column: "ExperienceId",
                principalTable: "Experience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
