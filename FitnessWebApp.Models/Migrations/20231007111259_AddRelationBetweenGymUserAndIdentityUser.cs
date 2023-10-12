using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApp.Models.Migrations
{
    public partial class AddRelationBetweenGymUserAndIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "GymUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GymUsers_UserId",
                table: "GymUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GymUsers_AspNetUsers_UserId",
                table: "GymUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymUsers_AspNetUsers_UserId",
                table: "GymUsers");

            migrationBuilder.DropIndex(
                name: "IX_GymUsers_UserId",
                table: "GymUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GymUsers");
        }
    }
}
