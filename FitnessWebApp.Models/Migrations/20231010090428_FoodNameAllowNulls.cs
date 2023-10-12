using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApp.Models.Migrations
{
    public partial class FoodNameAllowNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                type: "nvarchar(171)",
                maxLength: 171,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(171)",
                oldMaxLength: 171);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                type: "nvarchar(171)",
                maxLength: 171,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(171)",
                oldMaxLength: 171,
                oldNullable: true);
        }
    }
}
