using Microsoft.EntityFrameworkCore.Migrations;

namespace Secretary.API.Migrations
{
    public partial class afterCountry1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                schema: "secretary",
                table: "Publicador",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publicador_CountryId",
                schema: "secretary",
                table: "Publicador",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicador_Country_CountryId",
                schema: "secretary",
                table: "Publicador",
                column: "CountryId",
                principalSchema: "secretary",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicador_Country_CountryId",
                schema: "secretary",
                table: "Publicador");

            migrationBuilder.DropIndex(
                name: "IX_Publicador_CountryId",
                schema: "secretary",
                table: "Publicador");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "secretary",
                table: "Publicador");
        }
    }
}
