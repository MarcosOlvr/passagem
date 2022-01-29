using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Passagem.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cargos_CargoId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CargoId",
                table: "Users",
                newName: "CargoFK");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CargoId",
                table: "Users",
                newName: "IX_Users_CargoFK");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Noticias",
                newName: "NoticiaId");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Categorias",
                newName: "CategoriaNome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorias",
                newName: "CategoriaId");

            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "Cargos",
                newName: "CargoNome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cargos",
                newName: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cargos_CargoFK",
                table: "Users",
                column: "CargoFK",
                principalTable: "Cargos",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cargos_CargoFK",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CargoFK",
                table: "Users",
                newName: "CargoId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CargoFK",
                table: "Users",
                newName: "IX_Users_CargoId");

            migrationBuilder.RenameColumn(
                name: "NoticiaId",
                table: "Noticias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoriaNome",
                table: "Categorias",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Categorias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CargoNome",
                table: "Cargos",
                newName: "Cargo");

            migrationBuilder.RenameColumn(
                name: "CargoId",
                table: "Cargos",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cargos_CargoId",
                table: "Users",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
