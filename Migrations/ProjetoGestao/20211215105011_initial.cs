using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoGestao.Migrations.ProjetoGestao
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    FuncaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncao = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.FuncaoId);
                });

            migrationBuilder.CreateTable(
                name: "Gestor",
                columns: table => new
                {
                    GestorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGestor = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienciaComoGestor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestor", x => x.GestorId);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeColaborador = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.ColaboradorId);
                    table.ForeignKey(
                        name: "FK_Colaborador_Funcao_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcao",
                        principalColumn: "FuncaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProjeto = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DescricaoProjeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPrevistaInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEfetivaInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEfetivaFim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPrevistaFim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GestorId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.ProjetoId);
                    table.ForeignKey(
                        name: "FK_Projeto_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projeto_Gestor_GestorId",
                        column: x => x.GestorId,
                        principalTable: "Gestor",
                        principalColumn: "GestorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradoresProjeto",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradoresProjeto", x => new { x.ProjetoId, x.ColaboradorId });
                    table.ForeignKey(
                        name: "FK_ColaboradoresProjeto_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColaboradoresProjeto_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relatorio",
                columns: table => new
                {
                    RelatorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRelatorio = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DataEfetivaInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorio", x => x.RelatorioId);
                    table.ForeignKey(
                        name: "FK_Relatorio_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    TarefaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTarefa = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DataPrevistaInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEfetivaInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEfetivaFim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPrevistaFim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColaboradorResponsavelTarefa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoTarefa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefa_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_FuncaoId",
                table: "Colaborador",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradoresProjeto_ColaboradorId",
                table: "ColaboradoresProjeto",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_ClienteId",
                table: "Projeto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_GestorId",
                table: "Projeto",
                column: "GestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorio_ProjetoId",
                table: "Relatorio",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ProjetoId",
                table: "Tarefa",
                column: "ProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradoresProjeto");

            migrationBuilder.DropTable(
                name: "Relatorio");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "Funcao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Gestor");
        }
    }
}
