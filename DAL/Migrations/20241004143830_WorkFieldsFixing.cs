using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireMeAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class WorkFieldsFixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceWorkFields_WorkFieldId",
                table: "ExperienceWorkFields",
                column: "WorkFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceWorkFields_WorkFields_WorkFieldId",
                table: "ExperienceWorkFields",
                column: "WorkFieldId",
                principalTable: "WorkFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceWorkFields_WorkFields_WorkFieldId",
                table: "ExperienceWorkFields");

            migrationBuilder.DropIndex(
                name: "IX_ExperienceWorkFields_WorkFieldId",
                table: "ExperienceWorkFields");

            
        }
    }
}
