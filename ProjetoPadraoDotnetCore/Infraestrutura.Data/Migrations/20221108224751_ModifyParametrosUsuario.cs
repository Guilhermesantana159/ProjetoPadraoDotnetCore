using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class ModifyParametrosUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "USUARIO");

            migrationBuilder.AddColumn<bool>(
                name: "PerfilAdministrador",
                table: "USUARIO",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerfilAdministrador",
                table: "USUARIO");

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "USUARIO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
