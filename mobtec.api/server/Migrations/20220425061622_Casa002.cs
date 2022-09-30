using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class Casa002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cidade",
                table: "Casas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "Casas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "Casas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "oculto",
                table: "Casas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Casas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cidade",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "descricao",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "endereco",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "oculto",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Casas");
        }
    }
}
