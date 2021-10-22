using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class CadastroCliente003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "facebook",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "instagram",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "linkedin",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "snAtivo",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "twitter",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "whatsApp",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "youtube",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "endereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "facebook",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "instagram",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "linkedin",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "snAtivo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "twitter",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "whatsApp",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "youtube",
                table: "Clientes");
        }
    }
}
