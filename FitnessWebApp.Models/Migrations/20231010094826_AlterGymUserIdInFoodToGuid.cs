using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApp.Models.Migrations
{
    public partial class AlterGymUserIdInFoodToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodGymUser");

            migrationBuilder.DropColumn(
                name: "GymUsersId",
                table: "Foods");

            migrationBuilder.AddColumn<Guid>(
                name: "GymUserId",
                table: "Foods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GymUsersFoodsId",
                table: "Foods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_GymUserId",
                table: "Foods",
                column: "GymUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_GymUsers_GymUserId",
                table: "Foods",
                column: "GymUserId",
                principalTable: "GymUsers",
                principalColumn: "GymUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_GymUsers_GymUserId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_GymUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "GymUserId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "GymUsersFoodsId",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "GymUsersId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodGymUser",
                columns: table => new
                {
                    EatedFoodFoodId = table.Column<int>(type: "int", nullable: false),
                    GymUsersGymUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodGymUser", x => new { x.EatedFoodFoodId, x.GymUsersGymUserId });
                    table.ForeignKey(
                        name: "FK_FoodGymUser_Foods_EatedFoodFoodId",
                        column: x => x.EatedFoodFoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodGymUser_GymUsers_GymUsersGymUserId",
                        column: x => x.GymUsersGymUserId,
                        principalTable: "GymUsers",
                        principalColumn: "GymUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodGymUser_GymUsersGymUserId",
                table: "FoodGymUser",
                column: "GymUsersGymUserId");
        }
    }
}
