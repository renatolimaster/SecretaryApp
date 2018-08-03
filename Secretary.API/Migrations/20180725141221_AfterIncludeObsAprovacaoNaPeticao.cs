using Microsoft.EntityFrameworkCore.Migrations;

namespace Secretary.API.Migrations
{
    public partial class AfterIncludeObsAprovacaoNaPeticao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaAprovado",
                schema: "secretary",
                table: "PeticaoPioneiroAuxiliar",
                type: "boolean",
                nullable: false,
                defaultValueSql: "FALSE");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                schema: "secretary",
                table: "PeticaoPioneiroAuxiliar",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaAprovado",
                schema: "secretary",
                table: "PeticaoPioneiroAuxiliar");

            migrationBuilder.DropColumn(
                name: "Observacao",
                schema: "secretary",
                table: "PeticaoPioneiroAuxiliar");
        }
    }
}
