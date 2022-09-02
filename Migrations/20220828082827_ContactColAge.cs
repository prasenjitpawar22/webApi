using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebAPICore.Migrations
{
    public partial class ContactColAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Contact",
                type: "integer",
                nullable: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Contact");
        }
    }
}
