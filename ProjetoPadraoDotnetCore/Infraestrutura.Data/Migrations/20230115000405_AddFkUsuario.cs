using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class AddFkUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioFkIdUsuario",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioFkIdUsuario",
                table: "Usuario",
                column: "UsuarioFkIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Usuario_UsuarioFkIdUsuario",
                table: "Usuario",
                column: "UsuarioFkIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Usuario_UsuarioFkIdUsuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_UsuarioFkIdUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioFkIdUsuario",
                table: "Usuario");
        }
    }
}
