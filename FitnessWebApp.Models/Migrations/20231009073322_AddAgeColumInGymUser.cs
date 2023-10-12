using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApp.Models.Migrations
{
    public partial class AddAgeColumInGymUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "GymUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "GymUsers");
        }
    }
}
