using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebListaEsperaMentoriaIdentity.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoModelProfissionais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROFISSIONAL_ESPECIALIDADE_EspecialidadeId",
                table: "PROFISSIONAL");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PROFISSIONAL",
                newName: "Nome");

            migrationBuilder.AlterColumn<int>(
                name: "EspecialidadeId",
                table: "PROFISSIONAL",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PROFISSIONAL_ESPECIALIDADE_EspecialidadeId",
                table: "PROFISSIONAL",
                column: "EspecialidadeId",
                principalTable: "ESPECIALIDADE",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROFISSIONAL_ESPECIALIDADE_EspecialidadeId",
                table: "PROFISSIONAL");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "PROFISSIONAL",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "EspecialidadeId",
                table: "PROFISSIONAL",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PROFISSIONAL_ESPECIALIDADE_EspecialidadeId",
                table: "PROFISSIONAL",
                column: "EspecialidadeId",
                principalTable: "ESPECIALIDADE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
