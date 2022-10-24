using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class ConfigsSobre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bannerSobre",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descricaoSobre",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bannerSobre",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "descricaoSobre",
                table: "Clientes");
        }
    }
}
