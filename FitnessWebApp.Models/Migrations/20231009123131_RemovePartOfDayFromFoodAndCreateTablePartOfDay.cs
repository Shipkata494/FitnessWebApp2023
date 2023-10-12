using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApp.Models.Migrations
{
    public partial class RemovePartOfDayFromFoodAndCreateTablePartOfDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PartOfDay",
                table: "Foods",
                newName: "PartOfDayId");

            migrationBuilder.CreateTable(
                name: "PartOfDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfDay", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PartOfDay",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Diner" },
                    { 4, "Snack" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PartOfDayId",
                table: "Foods",
                column: "PartOfDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_PartOfDay_PartOfDayId",
                table: "Foods",
                column: "PartOfDayId",
                principalTable: "PartOfDay",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_PartOfDay_PartOfDayId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "PartOfDay");

            migrationBuilder.DropIndex(
                name: "IX_Foods_PartOfDayId",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "PartOfDayId",
                table: "Foods",
                newName: "PartOfDay");
        }
    }
}
