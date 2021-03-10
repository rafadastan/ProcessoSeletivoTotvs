using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessoSeletivoTotvs.Infra.Data.Migrations
{
    public partial class secondMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfil_Usuario_Id",
                table: "Perfil");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Perfil",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_UsuarioId",
                table: "Perfil",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfil_Usuario_UsuarioId",
                table: "Perfil",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfil_Usuario_UsuarioId",
                table: "Perfil");

            migrationBuilder.DropIndex(
                name: "IX_Perfil_UsuarioId",
                table: "Perfil");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Perfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfil_Usuario_Id",
                table: "Perfil",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
