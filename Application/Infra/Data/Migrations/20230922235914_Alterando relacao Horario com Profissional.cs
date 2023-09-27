using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class AlterandorelacaoHorariocomProfissional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfissionalIdProfissional",
                table: "HorarioDisponivel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDisponivel_ProfissionalIdProfissional",
                table: "HorarioDisponivel",
                column: "ProfissionalIdProfissional");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDisponivel_Profissional_ProfissionalIdProfissional",
                table: "HorarioDisponivel",
                column: "ProfissionalIdProfissional",
                principalTable: "Profissional",
                principalColumn: "IdProfissional");
        }
    }
}
