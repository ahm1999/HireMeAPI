﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireMeAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingExperienceFkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Users_UserId",
                table: "Experience");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Experience",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Users_UserId",
                table: "Experience",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Users_UserId",
                table: "Experience");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Experience",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Users_UserId",
                table: "Experience",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
