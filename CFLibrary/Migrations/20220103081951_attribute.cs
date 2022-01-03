using Microsoft.EntityFrameworkCore.Migrations;

namespace CFLibrary.Migrations
{
    public partial class attribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "Book",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Book",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Book");
        }
    }
}
