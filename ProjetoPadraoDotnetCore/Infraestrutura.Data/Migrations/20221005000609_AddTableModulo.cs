using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    public partial class AddTableModulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TELEFONE",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "MODULO",
                columns: table => new
                {
                    IdModulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAOLABEL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODULO", x => x.IdModulo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MODULO");

            migrationBuilder.AlterColumn<string>(
                name: "TELEFONE",
                table: "USUARIO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
