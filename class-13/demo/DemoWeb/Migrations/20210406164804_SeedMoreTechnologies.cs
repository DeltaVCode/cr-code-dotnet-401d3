using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWeb.Migrations
{
    public partial class SeedMoreTechnologies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "JavaScript");

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Java" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Node.js");
        }
    }
}
