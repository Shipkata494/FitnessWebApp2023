using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApp.Models.Migrations
{
    public partial class AddGymUserIdColumInFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodGymUser");

            migrationBuilder.DropColumn(
                name: "GymUsersId",
                table: "Foods");
        }
    }
}
