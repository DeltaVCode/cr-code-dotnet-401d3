using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWeb.Migrations
{
    public partial class AddVeteranPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "VeteranPrice",
                table: "Courses",
                type: "money",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VeteranPrice",
                table: "Courses");
        }
    }
}
