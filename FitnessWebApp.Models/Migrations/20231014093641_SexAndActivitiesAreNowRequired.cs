using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApp.Models.Migrations
{
    public partial class SexAndActivitiesAreNowRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymUsers_Activities_ActivitiId",
                table: "GymUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Sex",
                table: "GymUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActivitiId",
                table: "GymUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GymUsers_Activities_ActivitiId",
                table: "GymUsers",
                column: "ActivitiId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymUsers_Activities_ActivitiId",
                table: "GymUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Sex",
                table: "GymUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActivitiId",
                table: "GymUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GymUsers_Activities_ActivitiId",
                table: "GymUsers",
                column: "ActivitiId",
                principalTable: "Activities",
                principalColumn: "Id");
        }
    }
}
