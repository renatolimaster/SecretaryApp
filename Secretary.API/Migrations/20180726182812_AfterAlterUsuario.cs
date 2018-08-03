using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Secretary.API.Migrations
{
    public partial class AfterAlterUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "secretary",
                table: "usuario");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHarsh",
                schema: "secretary",
                table: "usuario",
                maxLength: 255,
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                schema: "secretary",
                table: "usuario",
                maxLength: 255,
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHarsh",
                schema: "secretary",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "secretary",
                table: "usuario");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "secretary",
                table: "usuario",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
