using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class Casa004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "banner01",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "banner02",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "banner03",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "banner01",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "banner02",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "banner03",
                table: "Clientes");
        }
    }
}
