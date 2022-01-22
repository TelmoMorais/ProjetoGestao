using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoGestao.Migrations.ProjetoGestao
{
    public partial class src : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "Tarefa",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataEfetivaInicio",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DataEfetivaFim",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ColaboradorId",
                table: "Tarefa",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Colaborador_ColaboradorId",
                table: "Tarefa",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Colaborador_ColaboradorId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_ColaboradorId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Tarefa");

            migrationBuilder.AlterColumn<string>(
                name: "DataEfetivaInicio",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataEfetivaFim",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
