using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Secretary.API.Migrations
{
    public partial class indexAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                schema: "secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    adminCode1 = table.Column<string>(nullable: true),
                    lng = table.Column<string>(nullable: true),
                    geonameId = table.Column<int>(nullable: false),
                    toponymName = table.Column<string>(nullable: true),
                    countryId = table.Column<string>(nullable: true),
                    fcl = table.Column<string>(nullable: true),
                    population = table.Column<int>(nullable: false),
                    countryCode = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    fclName = table.Column<string>(nullable: true),
                    adminCodes1_ISO3166_2 = table.Column<string>(nullable: true),
                    countryName = table.Column<string>(nullable: true),
                    fcodeName = table.Column<string>(nullable: true),
                    adminName1 = table.Column<string>(nullable: true),
                    fcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "FK_Estado_AdminCode1",
                schema: "secretary",
                table: "Estado",
                column: "adminCode1");

            migrationBuilder.CreateIndex(
                name: "FK_Estado_CountryName",
                schema: "secretary",
                table: "Estado",
                column: "countryName");

            migrationBuilder.CreateIndex(
                name: "FK_Estado_GeonameId",
                schema: "secretary",
                table: "Estado",
                column: "geonameId");

            migrationBuilder.CreateIndex(
                name: "FK_Estado_Name",
                schema: "secretary",
                table: "Estado",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "FK_Estado_ToponymName",
                schema: "secretary",
                table: "Estado",
                column: "toponymName");

            migrationBuilder.CreateIndex(
                name: "FK_Country_Name",
                schema: "secretary",
                table: "Country",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "FK_Country_CountryCode",
                schema: "secretary",
                table: "Country",
                column: "countryCode");

            migrationBuilder.CreateIndex(
                name: "FK_Country_CountryName",
                schema: "secretary",
                table: "Country",
                column: "countryName");

            migrationBuilder.CreateIndex(
                name: "FK_Cidade_adminCode1",
                schema: "secretary",
                table: "Cidade",
                column: "adminCode1");

            migrationBuilder.CreateIndex(
                name: "FK_Cidade_AdminName1",
                schema: "secretary",
                table: "Cidade",
                column: "adminName1");

            migrationBuilder.CreateIndex(
                name: "FK_Cidade_CountryId",
                schema: "secretary",
                table: "Cidade",
                column: "countryCode");

            migrationBuilder.CreateIndex(
                name: "FK_Cidade_CountryName",
                schema: "secretary",
                table: "Cidade",
                column: "countryName");

            migrationBuilder.CreateIndex(
                name: "FK_Cidade_GeonameId",
                schema: "secretary",
                table: "Cidade",
                column: "geonameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidade",
                schema: "secretary");

            migrationBuilder.DropIndex(
                name: "FK_Estado_AdminCode1",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "FK_Estado_CountryName",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "FK_Estado_GeonameId",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "FK_Estado_Name",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "FK_Estado_ToponymName",
                schema: "secretary",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "FK_Country_Name",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "FK_Country_CountryCode",
                schema: "secretary",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "FK_Country_CountryName",
                schema: "secretary",
                table: "Country");
        }
    }
}
