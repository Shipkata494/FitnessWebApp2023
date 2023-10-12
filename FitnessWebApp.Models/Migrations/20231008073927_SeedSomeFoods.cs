using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApp.Models.Migrations
{
    public partial class SeedSomeFoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Carbs", "EatingTime", "Fat", "Name", "PartOfDay", "Protein" },
                values: new object[] { 1, 0.0, null, 3.6000000000000001, "Chicken breast", null, 31.0 });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Carbs", "EatingTime", "Fat", "Name", "PartOfDay", "Protein" },
                values: new object[] { 2, 0.0, null, 10.0, "Beef steak", null, 35.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2);
        }
    }
}
