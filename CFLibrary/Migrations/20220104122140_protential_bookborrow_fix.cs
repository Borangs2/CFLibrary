using Microsoft.EntityFrameworkCore.Migrations;

namespace CFLibrary.Migrations
{
    public partial class protential_bookborrow_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookBorrow",
                table: "BookBorrow");

            migrationBuilder.AddColumn<int>(
                name: "BorrowId",
                table: "BookBorrow",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookBorrow",
                table: "BookBorrow",
                column: "BorrowId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrow_UserId",
                table: "BookBorrow",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookBorrow",
                table: "BookBorrow");

            migrationBuilder.DropIndex(
                name: "IX_BookBorrow_UserId",
                table: "BookBorrow");

            migrationBuilder.DropColumn(
                name: "BorrowId",
                table: "BookBorrow");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookBorrow",
                table: "BookBorrow",
                columns: new[] { "UserId", "BookId" });
        }
    }
}
