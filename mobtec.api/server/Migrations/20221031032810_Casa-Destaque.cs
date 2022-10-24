using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class CasaDestaque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "destaque",
                table: "Casas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "destaque",
                table: "Casas");
        }
    }
}
