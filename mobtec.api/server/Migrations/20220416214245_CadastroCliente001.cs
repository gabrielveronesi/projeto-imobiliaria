using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class CadastroCliente001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nome",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "acessoClienteusuario",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "logo",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nomeCliente",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nomeComercial",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "urlCliente",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.usuario);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_acessoClienteusuario",
                table: "Clientes",
                column: "acessoClienteusuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Login_acessoClienteusuario",
                table: "Clientes",
                column: "acessoClienteusuario",
                principalTable: "Login",
                principalColumn: "usuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Login_acessoClienteusuario",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_acessoClienteusuario",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "acessoClienteusuario",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "logo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "nomeCliente",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "nomeComercial",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "urlCliente",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
