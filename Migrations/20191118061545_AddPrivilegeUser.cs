using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPServer.Migrations
{
    public partial class AddPrivilegeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterColumn<decimal>(
            //     name: "UserID",
            //     table: "Users",
            //     nullable: false,
            //     oldClrType: typeof(decimal),
            //     oldType: "decimal(20,0)")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "RelationID",
            //     table: "UserRoleRelation",
            //     nullable: false,
            //     oldClrType: typeof(decimal),
            //     oldType: "decimal(20,0)")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "RelationID",
            //     table: "RoleRightRelation",
            //     nullable: false,
            //     oldClrType: typeof(decimal),
            //     oldType: "decimal(20,0)")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "RoleID",
            //     table: "Role",
            //     nullable: false,
            //     oldClrType: typeof(decimal),
            //     oldType: "decimal(20,0)")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "RightID",
            //     table: "Right",
            //     nullable: false,
            //     oldClrType: typeof(decimal),
            //     oldType: "decimal(20,0)")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "LogID",
            //     table: "OperationLog",
            //     nullable: false,
            //     oldClrType: typeof(decimal),
            //     oldType: "decimal(20,0)")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "DepartmentID",
            //     table: "Department",
            //     nullable: false,
            //     oldClrType: typeof(decimal),
            //     oldType: "decimal(20,0)")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreateTime", "CurrentLoginTime", "Email", "LastLoginTime", "LoginCount", "LoginName", "MobileNum", "Password", "UserName" },
                values: new object[] { 1m, new DateTime(2019, 11, 18, 14, 15, 44, 967, DateTimeKind.Local).AddTicks(8513), new DateTime(2019, 11, 18, 14, 15, 44, 968, DateTimeKind.Local).AddTicks(4999), "", new DateTime(2019, 11, 18, 14, 15, 44, 968, DateTimeKind.Local).AddTicks(4714), 0m, "SuperAdmin", "13584584928", "202CB962AC59075B964B07152D234B70", "丁瑞琦" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1m);

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "UserID",
            //     table: "Users",
            //     type: "decimal(20,0)",
            //     nullable: false,
            //     oldClrType: typeof(decimal))
            //     .Annotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "RelationID",
            //     table: "UserRoleRelation",
            //     type: "decimal(20,0)",
            //     nullable: false,
            //     oldClrType: typeof(decimal))
            //     .Annotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "RelationID",
            //     table: "RoleRightRelation",
            //     type: "decimal(20,0)",
            //     nullable: false,
            //     oldClrType: typeof(decimal))
            //     .Annotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "RoleID",
            //     table: "Role",
            //     type: "decimal(20,0)",
            //     nullable: false,
            //     oldClrType: typeof(decimal))
            //     .Annotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "RightID",
            //     table: "Right",
            //     type: "decimal(20,0)",
            //     nullable: false,
            //     oldClrType: typeof(decimal))
            //     .Annotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "LogID",
            //     table: "OperationLog",
            //     type: "decimal(20,0)",
            //     nullable: false,
            //     oldClrType: typeof(decimal))
            //     .Annotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<decimal>(
            //     name: "DepartmentID",
            //     table: "Department",
            //     type: "decimal(20,0)",
            //     nullable: false,
            //     oldClrType: typeof(decimal))
            //     .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
