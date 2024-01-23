using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApi.Migrations
{
    public partial class ConvertToSt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genras_genrasID",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_genrasID",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "genrasID",
                table: "movies");

            migrationBuilder.CreateIndex(
                name: "IX_movies_GenraId",
                table: "movies",
                column: "GenraId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genras_GenraId",
                table: "movies",
                column: "GenraId",
                principalTable: "genras",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genras_GenraId",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_GenraId",
                table: "movies");

            migrationBuilder.AddColumn<int>(
                name: "genrasID",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_movies_genrasID",
                table: "movies",
                column: "genrasID");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genras_genrasID",
                table: "movies",
                column: "genrasID",
                principalTable: "genras",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
