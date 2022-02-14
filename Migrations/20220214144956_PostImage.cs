using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Passagem.Migrations
{
    public partial class PostImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Conteudo",
                table: "Noticias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoImagem",
                table: "Noticias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Noticias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoImagem",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Noticias");

            migrationBuilder.AlterColumn<string>(
                name: "Conteudo",
                table: "Noticias",
                type: "ntext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
