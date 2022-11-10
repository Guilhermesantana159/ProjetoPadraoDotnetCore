using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class ModifyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TELEFONE",
                table: "USUARIO",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "SENHA",
                table: "USUARIO",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "USUARIO",
                newName: "Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "USUARIO",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dedicacao",
                table: "USUARIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "USUARIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProfissao",
                table: "USUARIO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioCadastro",
                table: "USUARIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeMae",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomePai",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "USUARIO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SkillUsuario",
                columns: table => new
                {
                    LSkillIdSkill = table.Column<int>(type: "int", nullable: false),
                    LUsuarioIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillUsuario", x => new { x.LSkillIdSkill, x.LUsuarioIdUsuario });
                    table.ForeignKey(
                        name: "FK_SkillUsuario_Skill_LSkillIdSkill",
                        column: x => x.LSkillIdSkill,
                        principalTable: "Skill",
                        principalColumn: "IdSkill",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillUsuario_USUARIO_LUsuarioIdUsuario",
                        column: x => x.LUsuarioIdUsuario,
                        principalTable: "USUARIO",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_IdProfissao",
                table: "USUARIO",
                column: "IdProfissao");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUsuario_LUsuarioIdUsuario",
                table: "SkillUsuario",
                column: "LUsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIO_Profissao_IdProfissao",
                table: "USUARIO",
                column: "IdProfissao",
                principalTable: "Profissao",
                principalColumn: "IdProfissao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIO_Profissao_IdProfissao",
                table: "USUARIO");

            migrationBuilder.DropTable(
                name: "SkillUsuario");

            migrationBuilder.DropIndex(
                name: "IX_USUARIO_IdProfissao",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Dedicacao",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "IdProfissao",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "IdUsuarioCadastro",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "NomeMae",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "NomePai",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "USUARIO");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "USUARIO",
                newName: "TELEFONE");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "USUARIO",
                newName: "SENHA");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "USUARIO",
                newName: "EMAIL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "USUARIO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
