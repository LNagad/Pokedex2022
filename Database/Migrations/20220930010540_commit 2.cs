using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class commit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_PokemonTypes_SecundaryTypeId",
                table: "Pokemons");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_PokemonTypes_SecundaryTypeId",
                table: "Pokemons",
                column: "SecundaryTypeId",
                principalTable: "PokemonTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_PokemonTypes_SecundaryTypeId",
                table: "Pokemons");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_PokemonTypes_SecundaryTypeId",
                table: "Pokemons",
                column: "SecundaryTypeId",
                principalTable: "PokemonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
