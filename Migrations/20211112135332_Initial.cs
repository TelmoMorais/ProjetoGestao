using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoGestao.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NovoColaborador",
                columns: table => new
                {
                    NovoColaboradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeColaborador = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovoColaborador", x => x.NovoColaboradorId);
                });

            migrationBuilder.CreateTable(
                name: "NovoGestor",
                columns: table => new
                {
                    NovoGestorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGestor = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovoGestor", x => x.NovoGestorId);
                });

            migrationBuilder.CreateTable(
                name: "NovoProjeto",
                columns: table => new
                {
                    NovoProjetoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProjeto = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DescricaoProjeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NovoGestorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovoProjeto", x => x.NovoProjetoId);
                    table.ForeignKey(
                        name: "FK_NovoProjeto_NovoGestor_NovoGestorId",
                        column: x => x.NovoGestorId,
                        principalTable: "NovoGestor",
                        principalColumn: "NovoGestorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NovoColaboradorNovoProjeto",
                columns: table => new
                {
                    ColaboradorsNovoColaboradorId = table.Column<int>(type: "int", nullable: false),
                    ProjetosNovoProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovoColaboradorNovoProjeto", x => new { x.ColaboradorsNovoColaboradorId, x.ProjetosNovoProjetoId });
                    table.ForeignKey(
                        name: "FK_NovoColaboradorNovoProjeto_NovoColaborador_ColaboradorsNovoColaboradorId",
                        column: x => x.ColaboradorsNovoColaboradorId,
                        principalTable: "NovoColaborador",
                        principalColumn: "NovoColaboradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NovoColaboradorNovoProjeto_NovoProjeto_ProjetosNovoProjetoId",
                        column: x => x.ProjetosNovoProjetoId,
                        principalTable: "NovoProjeto",
                        principalColumn: "NovoProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovoColaboradorNovoProjeto_ProjetosNovoProjetoId",
                table: "NovoColaboradorNovoProjeto",
                column: "ProjetosNovoProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_NovoProjeto_NovoGestorId",
                table: "NovoProjeto",
                column: "NovoGestorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NovoColaboradorNovoProjeto");

            migrationBuilder.DropTable(
                name: "NovoColaborador");

            migrationBuilder.DropTable(
                name: "NovoProjeto");

            migrationBuilder.DropTable(
                name: "NovoGestor");
        }
    }
}
