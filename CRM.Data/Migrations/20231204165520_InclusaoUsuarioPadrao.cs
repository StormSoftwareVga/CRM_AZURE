using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Data.Migrations
{
    public partial class InclusaoUsuarioPadrao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO USUARIOS  VALUES (NEWID(), GETDATE(), GETDATE(), 'false', 'stormadm', 'desenvolvimento@sotrmsoftwares.com.br', '$2a$11$IaraZkEg0rs.xqZsZ4D.U.0N/YPSCDiYn1Ul1zER.EZKCI8EQmnsG')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM USUARIOS WHERE EMAIL = 'desenvolvimento@sotrmsoftwares.com.br'");

        }
    }
}
