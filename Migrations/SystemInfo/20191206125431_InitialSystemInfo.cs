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
                    CorporationLogo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemInfo", x => x.CorporationCode);
                });

            migrationBuilder.CreateTable(
                name: "SystemLicenseInfos",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 64, nullable: false),
                    OrganizationName = table.Column<string>(maxLength: 64, nullable: false),
                    ProductLicenseStartTime = table.Column<DateTime>(nullable: false),
                    ProductExpireTime = table.Column<DateTime>(nullable: false),
                    AuthorizedQuantity = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    Environment = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    Sign = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLicenseInfos", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "SystemModuleInfo",
                columns: table => new
                {
                    ModuleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(maxLength: 64, nullable: false),
                    ModuleLicenseStartTime = table.Column<DateTime>(nullable: false),
                    ModuleExpireTime = table.Column<DateTime>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    LicenseInfoProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemModuleInfo", x => x.ModuleID);
                    table.ForeignKey(
                        name: "FK_SystemModuleInfo_SystemLicenseInfos_LicenseInfoProductID",
                        column: x => x.LicenseInfoProductID,
                        principalTable: "SystemLicenseInfos",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "SystemInfo",
                columns: new[] { "CorporationCode", "CorporationAddress", "CorporationLogo", "CorporationName", "WebAddress" },
                values: new object[] { "kdixgioakfgehgi", null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_SystemModuleInfo_LicenseInfoProductID",
                table: "SystemModuleInfo",
                column: "LicenseInfoProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemInfo");

            migrationBuilder.DropTable(
                name: "SystemModuleInfo");

            migrationBuilder.DropTable(
                name: "SystemLicenseInfos");
        }
    }
}
