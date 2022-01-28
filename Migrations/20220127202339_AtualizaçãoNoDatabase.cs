using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Passagem.Migrations
{
    public partial class AtualizaçãoNoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Categorias_CategoriaId",
                table: "Noticias");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Noticias",
                newName: "CategoriaForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Noticias_CategoriaId",
                table: "Noticias",
                newName: "IX_Noticias_CategoriaForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Categorias_CategoriaForeignKey",
                table: "Noticias",
                column: "CategoriaForeignKey",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Categorias_CategoriaForeignKey",
                table: "Noticias");

            migrationBuilder.RenameColumn(
                name: "CategoriaForeignKey",
                table: "Noticias",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Noticias_CategoriaForeignKey",
                table: "Noticias",
                newName: "IX_Noticias_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Categorias_CategoriaId",
                table: "Noticias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
