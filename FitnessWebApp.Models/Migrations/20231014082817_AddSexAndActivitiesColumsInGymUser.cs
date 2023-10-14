using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWebApp.Models.Migrations
{
    public partial class AddSexAndActivitiesColumsInGymUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiviiID",
                table: "GymUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivitiId",
                table: "GymUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "GymUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymUsers_ActivitiId",
                table: "GymUsers",
                column: "ActivitiId");

            migrationBuilder.AddForeignKey(
                name: "FK_GymUsers_Activities_ActivitiId",
                table: "GymUsers",
                column: "ActivitiId",
                principalTable: "Activities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymUsers_Activities_ActivitiId",
                table: "GymUsers");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_GymUsers_ActivitiId",
                table: "GymUsers");

            migrationBuilder.DropColumn(
                name: "ActiviiID",
                table: "GymUsers");

            migrationBuilder.DropColumn(
                name: "ActivitiId",
                table: "GymUsers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "GymUsers");
        }
    }
}
