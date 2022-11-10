using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class Modifykill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillUsuario_Skill_LSkillIdSkill",
                table: "SkillUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillUsuario_USUARIO_LUsuarioIdUsuario",
                table: "SkillUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIO_Profissao_IdProfissao",
                table: "USUARIO");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USUARIO",
                table: "USUARIO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillUsuario",
                table: "SkillUsuario");

            migrationBuilder.RenameTable(
                name: "USUARIO",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_USUARIO_IdProfissao",
                table: "Usuario",
                newName: "IX_Usuario_IdProfissao");

            migrationBuilder.RenameColumn(
                name: "LUsuarioIdUsuario",
                table: "SkillUsuario",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "LSkillIdSkill",
                table: "SkillUsuario",
                newName: "IdSkill");

            migrationBuilder.RenameIndex(
                name: "IX_SkillUsuario_LUsuarioIdUsuario",
                table: "SkillUsuario",
                newName: "IX_SkillUsuario_IdUsuario");

            migrationBuilder.AlterColumn<int>(
                name: "IdSkill",
                table: "SkillUsuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "SkillUsuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillUsuario",
                table: "SkillUsuario",
                column: "IdSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUsuario_Usuario_IdUsuario",
                table: "SkillUsuario",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Profissao_IdProfissao",
                table: "Usuario",
                column: "IdProfissao",
                principalTable: "Profissao",
                principalColumn: "IdProfissao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillUsuario_Usuario_IdUsuario",
                table: "SkillUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Profissao_IdProfissao",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillUsuario",
                table: "SkillUsuario");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "SkillUsuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "USUARIO");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_IdProfissao",
                table: "USUARIO",
                newName: "IX_USUARIO_IdProfissao");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "SkillUsuario",
                newName: "LUsuarioIdUsuario");

            migrationBuilder.RenameColumn(
                name: "IdSkill",
                table: "SkillUsuario",
                newName: "LSkillIdSkill");

            migrationBuilder.RenameIndex(
                name: "IX_SkillUsuario_IdUsuario",
                table: "SkillUsuario",
                newName: "IX_SkillUsuario_LUsuarioIdUsuario");

            migrationBuilder.AlterColumn<int>(
                name: "LSkillIdSkill",
                table: "SkillUsuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUARIO",
                table: "USUARIO",
                column: "IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillUsuario",
                table: "SkillUsuario",
                columns: new[] { "LSkillIdSkill", "LUsuarioIdUsuario" });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.IdSkill);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUsuario_Skill_LSkillIdSkill",
                table: "SkillUsuario",
                column: "LSkillIdSkill",
                principalTable: "Skill",
                principalColumn: "IdSkill",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillUsuario_USUARIO_LUsuarioIdUsuario",
                table: "SkillUsuario",
                column: "LUsuarioIdUsuario",
                principalTable: "USUARIO",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIO_Profissao_IdProfissao",
                table: "USUARIO",
                column: "IdProfissao",
                principalTable: "Profissao",
                principalColumn: "IdProfissao");
        }
    }
}
