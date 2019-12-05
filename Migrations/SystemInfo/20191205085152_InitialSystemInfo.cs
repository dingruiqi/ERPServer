using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPServer.Migrations.SystemInfo
{
    public partial class InitialSystemInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemInfo",
                columns: table => new
                {
                    CorporationCode = table.Column<string>(nullable: false),
                    CorporationName = table.Column<string>(maxLength: 64, nullable: true),
                    CorporationAddress = table.Column<string>(maxLength: 64, nullable: true),
                    WebAddress = table.Column<string>(maxLength: 64, nullable: true),
                    CorporationLogo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemInfo", x => x.CorporationCode);
                });

            migrationBuilder.InsertData(
                table: "SystemInfo",
                columns: new[] { "CorporationCode", "CorporationAddress", "CorporationLogo", "CorporationName", "WebAddress" },
                values: new object[] { "kdixgioakfgehgi", null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemInfo");
        }
    }
}
