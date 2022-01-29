using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Passagem.Migrations
{
    public partial class CorrigindoCoisas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Categorias_CategoriaForeignKey",
                table: "Noticias");

            migrationBuilder.RenameColumn(
                name: "CategoriaForeignKey",
                table: "Noticias",
                newName: "CategoriaFK");

            migrationBuilder.RenameIndex(
                name: "IX_Noticias_CategoriaForeignKey",
                table: "Noticias",
                newName: "IX_Noticias_CategoriaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Categorias_CategoriaFK",
                table: "Noticias",
                column: "CategoriaFK",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Categorias_CategoriaFK",
                table: "Noticias");

            migrationBuilder.RenameColumn(
                name: "CategoriaFK",
                table: "Noticias",
                newName: "CategoriaForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Noticias_CategoriaFK",
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
    }
}
