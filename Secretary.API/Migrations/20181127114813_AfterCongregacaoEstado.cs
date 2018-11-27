using Microsoft.EntityFrameworkCore.Migrations;

namespace Secretary.API.Migrations
{
    public partial class AfterCongregacaoEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_usuario_Congregacao_CongregacaoId",
            //     schema: "secretary",
            //     table: "usuario");

            migrationBuilder.AlterColumn<long>(
                name: "PublicadorId",
                schema: "secretary",
                table: "usuario",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(long),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<long>(
                name: "CongregacaoId",
                schema: "secretary",
                table: "usuario",
                nullable: true,
                oldClrType: typeof(long));

            // migrationBuilder.AddForeignKey(
            //     name: "FK_usuario_Congregacao_CongregacaoId",
            //     schema: "secretary",
            //     table: "usuario",
            //     column: "CongregacaoId",
            //     principalSchema: "secretary",
            //     principalTable: "Congregacao",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_usuario_Congregacao_CongregacaoId",
            //     schema: "secretary",
            //     table: "usuario");

            migrationBuilder.AlterColumn<long>(
                name: "PublicadorId",
                schema: "secretary",
                table: "usuario",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(long),
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<long>(
                name: "CongregacaoId",
                schema: "secretary",
                table: "usuario",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_usuario_Congregacao_CongregacaoId",
            //     schema: "secretary",
            //     table: "usuario",
            //     column: "CongregacaoId",
            //     principalSchema: "secretary",
            //     principalTable: "Congregacao",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
