using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Data.Migrations
{
    public partial class InicioPermissoes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(9110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Regioes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8990),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Pessoas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8752),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "PessoaEnderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8281),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Municipios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8184),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8048),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsonCampos = table.Column<string>(type: "text", nullable: true),
                    Hash = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(7603)),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componente_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Papel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Json = table.Column<string>(type: "text", nullable: true),
                    PapelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8425)),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Papel_Papel_PapelId",
                        column: x => x.PapelId,
                        principalTable: "Papel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComponenteEndPoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponenteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(7871)),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteEndPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componente_EndPoint",
                        column: x => x.ComponenteID,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PapelComponente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PapelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponenteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8576)),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PapelComponente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Papel_PapelComponentes",
                        column: x => x.PapelID,
                        principalTable: "Papel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PapelComponente_Componente_ComponenteID",
                        column: x => x.ComponenteID,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPapel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PapelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(9232)),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPapel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioPapel_Papel_PapelID",
                        column: x => x.PapelID,
                        principalTable: "Papel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPapel_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componente_ComponenteId",
                table: "Componente",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteEndPoint_ComponenteID",
                table: "ComponenteEndPoint",
                column: "ComponenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Papel_PapelId",
                table: "Papel",
                column: "PapelId");

            migrationBuilder.CreateIndex(
                name: "IX_PapelComponente_ComponenteID",
                table: "PapelComponente",
                column: "ComponenteID");

            migrationBuilder.CreateIndex(
                name: "IX_PapelComponente_PapelID",
                table: "PapelComponente",
                column: "PapelID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPapel_PapelID",
                table: "UsuarioPapel",
                column: "PapelID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPapel_UsuarioID",
                table: "UsuarioPapel",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponenteEndPoint");

            migrationBuilder.DropTable(
                name: "PapelComponente");

            migrationBuilder.DropTable(
                name: "UsuarioPapel");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Papel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(9110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Regioes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Pessoas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8988),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "PessoaEnderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(9089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8867),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Municipios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInclusao",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 7, 21, 10, 4, 26, DateTimeKind.Local).AddTicks(8618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8048));
        }
    }
}
