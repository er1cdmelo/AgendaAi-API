using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class revolucaoHorario_Profissional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_HorarioDisponivel_Profissional_IdProfissional",
                table: "HorarioDisponivel",
                column: "IdProfissional",
                principalTable: "Profissional",
                principalColumn: "IdProfissional");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDisponivel_Profissional_ProfissionalIdProfissional",
                table: "HorarioDisponivel",
                column: "ProfissionalIdProfissional",
                principalTable: "Profissional",
                principalColumn: "IdProfissional");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDisponivel_Profissional_IdProfissional",
                table: "HorarioDisponivel");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDisponivel_Profissional_ProfissionalIdProfissional",
                table: "HorarioDisponivel");

            migrationBuilder.DropIndex(
                name: "IX_HorarioDisponivel_ProfissionalIdProfissional",
                table: "HorarioDisponivel");

            migrationBuilder.DropColumn(
                name: "ProfissionalIdProfissional",
                table: "HorarioDisponivel");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDisponivel_Profissional_IdProfissional",
                table: "HorarioDisponivel",
                column: "IdProfissional",
                principalTable: "Profissional",
                principalColumn: "IdProfissional",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
