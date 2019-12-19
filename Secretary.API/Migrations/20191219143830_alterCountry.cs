using Microsoft.EntityFrameworkCore.Migrations;

namespace Secretary.API.Migrations
{
    public partial class alterCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Anointed",
                schema: "secretary",
                table: "Publicador",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "areaInSqKm",
                schema: "secretary",
                table: "Country",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "capital",
                schema: "secretary",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "continent",
                schema: "secretary",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "continentName",
                schema: "secretary",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "countryCode",
                schema: "secretary",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "countryName",
                schema: "secretary",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "currencyCode",
                schema: "secretary",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "east",
                schema: "secretary",
                table: "Country",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fipsCode",
                schema: "secretary",
                table: "Country",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "geonameId",
                schema: "secretary",
                table: "Country",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "isoAlpha3",
                schema: "secretary",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "isoNumeric",
                schema: "secretary",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "languages",
                schema: "secretary",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "north",
                schema: "secretary",
                table: "Country",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "population",
                schema: "secretary",
                table: "Country",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "south",
                schema: "secretary",
                table: "Country",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "west",
                schema: "secretary",
                table: "Country",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "areaInSqKm",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "capital",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "continent",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "continentName",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "countryCode",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "countryName",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "currencyCode",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "east",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "fipsCode",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "geonameId",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "isoAlpha3",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "isoNumeric",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "languages",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "north",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "population",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "south",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "west",
                schema: "secretary",
                table: "Country");

            migrationBuilder.AlterColumn<bool>(
                name: "Anointed",
                schema: "secretary",
                table: "Publicador",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
