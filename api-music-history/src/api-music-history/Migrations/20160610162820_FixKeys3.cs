using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apimusichistory.Migrations
{
    public partial class FixKeys3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_AppUser_AppUserId1",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_AppUserId1",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "AppUser");

            migrationBuilder.CreateIndex(
                name: "IX_Track_AppUserId",
                table: "Track",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_AppUser_AppUserId",
                table: "Track",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_AppUser_AppUserId",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Track_AppUserId",
                table: "Track");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId1",
                table: "Track",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Track_AppUserId1",
                table: "Track",
                column: "AppUserId1");

            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "AppUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_AppUser_AppUserId1",
                table: "Track",
                column: "AppUserId1",
                principalTable: "AppUser",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
