using Microsoft.EntityFrameworkCore.Migrations;

namespace Secretary.API.Migrations
{
    public partial class AlterModelAttibutteCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Dianteira$FK_Estado_Country",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "FK_Estado_Country",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.RenameColumn(
                name: "toponymName",
                schema: "secretary",
                table: "Estado",
                newName: "ToponymName");

            migrationBuilder.RenameColumn(
                name: "population",
                schema: "secretary",
                table: "Estado",
                newName: "Population");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "secretary",
                table: "Estado",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "lng",
                schema: "secretary",
                table: "Estado",
                newName: "Lng");

            migrationBuilder.RenameColumn(
                name: "lat",
                schema: "secretary",
                table: "Estado",
                newName: "Lat");

            migrationBuilder.RenameColumn(
                name: "geonameId",
                schema: "secretary",
                table: "Estado",
                newName: "GeonameId");

            migrationBuilder.RenameColumn(
                name: "fcodeName",
                schema: "secretary",
                table: "Estado",
                newName: "FcodeName");

            migrationBuilder.RenameColumn(
                name: "fcode",
                schema: "secretary",
                table: "Estado",
                newName: "Fcode");

            migrationBuilder.RenameColumn(
                name: "fclName",
                schema: "secretary",
                table: "Estado",
                newName: "FclName");

            migrationBuilder.RenameColumn(
                name: "fcl",
                schema: "secretary",
                table: "Estado",
                newName: "Fcl");

            migrationBuilder.RenameColumn(
                name: "countryName",
                schema: "secretary",
                table: "Estado",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "countryId",
                schema: "secretary",
                table: "Estado",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "countryCode",
                schema: "secretary",
                table: "Estado",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "adminName1",
                schema: "secretary",
                table: "Estado",
                newName: "AdminName1");

            migrationBuilder.RenameColumn(
                name: "adminCodes1_ISO3166_2",
                schema: "secretary",
                table: "Estado",
                newName: "AdminCodes1_ISO3166_2");

            migrationBuilder.RenameColumn(
                name: "adminCode1",
                schema: "secretary",
                table: "Estado",
                newName: "AdminCode1");

            migrationBuilder.RenameColumn(
                name: "west",
                schema: "secretary",
                table: "Country",
                newName: "West");

            migrationBuilder.RenameColumn(
                name: "south",
                schema: "secretary",
                table: "Country",
                newName: "South");

            migrationBuilder.RenameColumn(
                name: "population",
                schema: "secretary",
                table: "Country",
                newName: "Population");

            migrationBuilder.RenameColumn(
                name: "north",
                schema: "secretary",
                table: "Country",
                newName: "North");

            migrationBuilder.RenameColumn(
                name: "languages",
                schema: "secretary",
                table: "Country",
                newName: "Languages");

            migrationBuilder.RenameColumn(
                name: "isoNumeric",
                schema: "secretary",
                table: "Country",
                newName: "IsoNumeric");

            migrationBuilder.RenameColumn(
                name: "isoAlpha3",
                schema: "secretary",
                table: "Country",
                newName: "IsoAlpha3");

            migrationBuilder.RenameColumn(
                name: "geonameId",
                schema: "secretary",
                table: "Country",
                newName: "GeonameId");

            migrationBuilder.RenameColumn(
                name: "fipsCode",
                schema: "secretary",
                table: "Country",
                newName: "FipsCode");

            migrationBuilder.RenameColumn(
                name: "east",
                schema: "secretary",
                table: "Country",
                newName: "East");

            migrationBuilder.RenameColumn(
                name: "currencyCode",
                schema: "secretary",
                table: "Country",
                newName: "CurrencyCode");

            migrationBuilder.RenameColumn(
                name: "countryName",
                schema: "secretary",
                table: "Country",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "countryCode",
                schema: "secretary",
                table: "Country",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "continentName",
                schema: "secretary",
                table: "Country",
                newName: "ContinentName");

            migrationBuilder.RenameColumn(
                name: "continent",
                schema: "secretary",
                table: "Country",
                newName: "Continent");

            migrationBuilder.RenameColumn(
                name: "capital",
                schema: "secretary",
                table: "Country",
                newName: "Capital");

            migrationBuilder.RenameColumn(
                name: "areaInSqKm",
                schema: "secretary",
                table: "Country",
                newName: "AreaInSqKm");

            migrationBuilder.RenameColumn(
                name: "toponymName",
                schema: "secretary",
                table: "Cidade",
                newName: "ToponymName");

            migrationBuilder.RenameColumn(
                name: "population",
                schema: "secretary",
                table: "Cidade",
                newName: "Population");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "secretary",
                table: "Cidade",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "lng",
                schema: "secretary",
                table: "Cidade",
                newName: "Lng");

            migrationBuilder.RenameColumn(
                name: "geonameId",
                schema: "secretary",
                table: "Cidade",
                newName: "GeonameId");

            migrationBuilder.RenameColumn(
                name: "fcodeName",
                schema: "secretary",
                table: "Cidade",
                newName: "FcodeName");

            migrationBuilder.RenameColumn(
                name: "fcode",
                schema: "secretary",
                table: "Cidade",
                newName: "Fcode");

            migrationBuilder.RenameColumn(
                name: "fclName",
                schema: "secretary",
                table: "Cidade",
                newName: "FclName");

            migrationBuilder.RenameColumn(
                name: "fcl",
                schema: "secretary",
                table: "Cidade",
                newName: "Fcl");

            migrationBuilder.RenameColumn(
                name: "countryName",
                schema: "secretary",
                table: "Cidade",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "countryId",
                schema: "secretary",
                table: "Cidade",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "countryCode",
                schema: "secretary",
                table: "Cidade",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "adminName1",
                schema: "secretary",
                table: "Cidade",
                newName: "AdminName1");

            migrationBuilder.RenameColumn(
                name: "adminCodes1_ISO3166_2",
                schema: "secretary",
                table: "Cidade",
                newName: "AdminCodes1_ISO3166_2");

            migrationBuilder.RenameColumn(
                name: "adminCode1",
                schema: "secretary",
                table: "Cidade",
                newName: "AdminCode1");

            migrationBuilder.AlterColumn<long>(
                name: "CountryId",
                schema: "secretary",
                table: "Estado",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CountryId",
                schema: "secretary",
                table: "Cidade",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "FK_Estado_Country",
                schema: "secretary",
                table: "Estado",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "Dianteira$FK_Estado_Country",
                schema: "secretary",
                table: "Estado",
                column: "CountryId",
                principalSchema: "secretary",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Dianteira$FK_Estado_Country",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "FK_Estado_Country",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.RenameColumn(
                name: "ToponymName",
                schema: "secretary",
                table: "Estado",
                newName: "toponymName");

            migrationBuilder.RenameColumn(
                name: "Population",
                schema: "secretary",
                table: "Estado",
                newName: "population");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "secretary",
                table: "Estado",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Lng",
                schema: "secretary",
                table: "Estado",
                newName: "lng");

            migrationBuilder.RenameColumn(
                name: "Lat",
                schema: "secretary",
                table: "Estado",
                newName: "lat");

            migrationBuilder.RenameColumn(
                name: "GeonameId",
                schema: "secretary",
                table: "Estado",
                newName: "geonameId");

            migrationBuilder.RenameColumn(
                name: "FcodeName",
                schema: "secretary",
                table: "Estado",
                newName: "fcodeName");

            migrationBuilder.RenameColumn(
                name: "Fcode",
                schema: "secretary",
                table: "Estado",
                newName: "fcode");

            migrationBuilder.RenameColumn(
                name: "FclName",
                schema: "secretary",
                table: "Estado",
                newName: "fclName");

            migrationBuilder.RenameColumn(
                name: "Fcl",
                schema: "secretary",
                table: "Estado",
                newName: "fcl");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                schema: "secretary",
                table: "Estado",
                newName: "countryName");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "secretary",
                table: "Estado",
                newName: "countryId");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                schema: "secretary",
                table: "Estado",
                newName: "countryCode");

            migrationBuilder.RenameColumn(
                name: "AdminName1",
                schema: "secretary",
                table: "Estado",
                newName: "adminName1");

            migrationBuilder.RenameColumn(
                name: "AdminCodes1_ISO3166_2",
                schema: "secretary",
                table: "Estado",
                newName: "adminCodes1_ISO3166_2");

            migrationBuilder.RenameColumn(
                name: "AdminCode1",
                schema: "secretary",
                table: "Estado",
                newName: "adminCode1");

            migrationBuilder.RenameColumn(
                name: "West",
                schema: "secretary",
                table: "Country",
                newName: "west");

            migrationBuilder.RenameColumn(
                name: "South",
                schema: "secretary",
                table: "Country",
                newName: "south");

            migrationBuilder.RenameColumn(
                name: "Population",
                schema: "secretary",
                table: "Country",
                newName: "population");

            migrationBuilder.RenameColumn(
                name: "North",
                schema: "secretary",
                table: "Country",
                newName: "north");

            migrationBuilder.RenameColumn(
                name: "Languages",
                schema: "secretary",
                table: "Country",
                newName: "languages");

            migrationBuilder.RenameColumn(
                name: "IsoNumeric",
                schema: "secretary",
                table: "Country",
                newName: "isoNumeric");

            migrationBuilder.RenameColumn(
                name: "IsoAlpha3",
                schema: "secretary",
                table: "Country",
                newName: "isoAlpha3");

            migrationBuilder.RenameColumn(
                name: "GeonameId",
                schema: "secretary",
                table: "Country",
                newName: "geonameId");

            migrationBuilder.RenameColumn(
                name: "FipsCode",
                schema: "secretary",
                table: "Country",
                newName: "fipsCode");

            migrationBuilder.RenameColumn(
                name: "East",
                schema: "secretary",
                table: "Country",
                newName: "east");

            migrationBuilder.RenameColumn(
                name: "CurrencyCode",
                schema: "secretary",
                table: "Country",
                newName: "currencyCode");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                schema: "secretary",
                table: "Country",
                newName: "countryName");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                schema: "secretary",
                table: "Country",
                newName: "countryCode");

            migrationBuilder.RenameColumn(
                name: "ContinentName",
                schema: "secretary",
                table: "Country",
                newName: "continentName");

            migrationBuilder.RenameColumn(
                name: "Continent",
                schema: "secretary",
                table: "Country",
                newName: "continent");

            migrationBuilder.RenameColumn(
                name: "Capital",
                schema: "secretary",
                table: "Country",
                newName: "capital");

            migrationBuilder.RenameColumn(
                name: "AreaInSqKm",
                schema: "secretary",
                table: "Country",
                newName: "areaInSqKm");

            migrationBuilder.RenameColumn(
                name: "ToponymName",
                schema: "secretary",
                table: "Cidade",
                newName: "toponymName");

            migrationBuilder.RenameColumn(
                name: "Population",
                schema: "secretary",
                table: "Cidade",
                newName: "population");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "secretary",
                table: "Cidade",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Lng",
                schema: "secretary",
                table: "Cidade",
                newName: "lng");

            migrationBuilder.RenameColumn(
                name: "GeonameId",
                schema: "secretary",
                table: "Cidade",
                newName: "geonameId");

            migrationBuilder.RenameColumn(
                name: "FcodeName",
                schema: "secretary",
                table: "Cidade",
                newName: "fcodeName");

            migrationBuilder.RenameColumn(
                name: "Fcode",
                schema: "secretary",
                table: "Cidade",
                newName: "fcode");

            migrationBuilder.RenameColumn(
                name: "FclName",
                schema: "secretary",
                table: "Cidade",
                newName: "fclName");

            migrationBuilder.RenameColumn(
                name: "Fcl",
                schema: "secretary",
                table: "Cidade",
                newName: "fcl");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                schema: "secretary",
                table: "Cidade",
                newName: "countryName");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "secretary",
                table: "Cidade",
                newName: "countryId");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                schema: "secretary",
                table: "Cidade",
                newName: "countryCode");

            migrationBuilder.RenameColumn(
                name: "AdminName1",
                schema: "secretary",
                table: "Cidade",
                newName: "adminName1");

            migrationBuilder.RenameColumn(
                name: "AdminCodes1_ISO3166_2",
                schema: "secretary",
                table: "Cidade",
                newName: "adminCodes1_ISO3166_2");

            migrationBuilder.RenameColumn(
                name: "AdminCode1",
                schema: "secretary",
                table: "Cidade",
                newName: "adminCode1");

            migrationBuilder.AlterColumn<string>(
                name: "countryId",
                schema: "secretary",
                table: "Estado",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "countryId",
                schema: "secretary",
                table: "Cidade",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "FK_Estado_Country",
                schema: "secretary",
                table: "Estado",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "Dianteira$FK_Estado_Country",
                schema: "secretary",
                table: "Estado",
                column: "CountryId",
                principalSchema: "secretary",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
