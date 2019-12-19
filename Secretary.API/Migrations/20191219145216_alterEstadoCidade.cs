using Microsoft.EntityFrameworkCore.Migrations;

namespace Secretary.API.Migrations
{
    public partial class alterEstadoCidade : Migration
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

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "secretary",
                table: "Estado",
                newName: "countryId");

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

            migrationBuilder.AddColumn<string>(
                name: "adminCode1",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "adminCodes1_ISO3166_2",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "adminName1",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "countryCode",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "countryName",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fcl",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fclName",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fcode",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fcodeName",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "geonameId",
                schema: "secretary",
                table: "Estado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "lat",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lng",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "secretary",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "population",
                schema: "secretary",
                table: "Estado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "toponymName",
                schema: "secretary",
                table: "Estado",
                nullable: true);

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

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "adminCode1",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "adminCodes1_ISO3166_2",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "adminName1",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "countryCode",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "countryName",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fcl",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fclName",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fcode",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fcodeName",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "geonameId",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "lat",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "lng",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "population",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "toponymName",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.RenameColumn(
                name: "countryId",
                schema: "secretary",
                table: "Estado",
                newName: "CountryId");

            migrationBuilder.AlterColumn<long>(
                name: "CountryId",
                schema: "secretary",
                table: "Estado",
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
    }
}
