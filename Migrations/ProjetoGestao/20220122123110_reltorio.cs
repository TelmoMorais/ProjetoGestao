using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoGestao.Migrations.ProjetoGestao
{
    public partial class reltorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Relatorio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Relatorio");
        }
    }
}
