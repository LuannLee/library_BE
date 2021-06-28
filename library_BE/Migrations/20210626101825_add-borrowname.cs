using Microsoft.EntityFrameworkCore.Migrations;

namespace library_BE.Migrations
{
    public partial class addborrowname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BorrowName",
                table: "Borrows",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowName",
                table: "Borrows");
        }
    }
}
