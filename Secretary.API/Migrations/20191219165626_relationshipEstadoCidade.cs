using Microsoft.EntityFrameworkCore.Migrations;

namespace Secretary.API.Migrations
{
    public partial class relationshipEstadoCidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EstadoId",
                schema: "secretary",
                table: "Cidade",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                schema: "secretary",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade_Estado_EstadoId",
                schema: "secretary",
                table: "Cidade",
                column: "EstadoId",
                principalSchema: "secretary",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_Estado_EstadoId",
                schema: "secretary",
                table: "Cidade");

            migrationBuilder.DropIndex(
                name: "IX_Cidade_EstadoId",
                schema: "secretary",
                table: "Cidade");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                schema: "secretary",
                table: "Cidade");
        }
    }
}
