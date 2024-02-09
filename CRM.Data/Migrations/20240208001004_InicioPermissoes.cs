using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Data.Migrations
{
    public partial class InicioPermissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(3199));

            migrationBuilder.AddColumn<bool>(
                name: "Inativo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Regioes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(3085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Pessoas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8988),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2809));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "PessoaEnderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8867),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Municipios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Inativo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(3199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Regioes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(3085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Pessoas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2809),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "PessoaEnderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2707),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Municipios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 13, 55, 20, 13, DateTimeKind.Local).AddTicks(2373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8618));
        }
    }
}
