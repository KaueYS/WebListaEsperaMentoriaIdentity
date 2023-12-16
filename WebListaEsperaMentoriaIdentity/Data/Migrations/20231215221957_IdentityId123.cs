using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebListaEsperaMentoriaIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdentityId123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "PACIENTES",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "PACIENTES",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PACIENTES_UsuarioId1",
                table: "PACIENTES",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PACIENTES_AspNetUsers_UsuarioId1",
                table: "PACIENTES",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PACIENTES_AspNetUsers_UsuarioId1",
                table: "PACIENTES");

            migrationBuilder.DropIndex(
                name: "IX_PACIENTES_UsuarioId1",
                table: "PACIENTES");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "PACIENTES");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "PACIENTES");
        }
    }
}
