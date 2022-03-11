using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheActivist.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Signed",
                table: "CauseClasses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Signed",
                table: "CauseClasses",
                type: "int",
                nullable: true);
        }
    }
}
