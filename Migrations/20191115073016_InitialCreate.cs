﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Right",
                columns: table => new
                {
                    RightID = table.Column<decimal>(nullable: false),
                    ParentRightID = table.Column<decimal>(nullable: false),
                    RightName = table.Column<string>(maxLength: 64, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Right", x => x.RightID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<decimal>(nullable: false),
                    ParentRoleID = table.Column<decimal>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 64, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<decimal>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    UserName = table.Column<string>(maxLength: 64, nullable: false),
                    MobileNum = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 64, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false),
                    CurrentLoginTime = table.Column<DateTime>(nullable: false),
                    LoginCount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "RoleRightRelation",
                columns: table => new
                {
                    RelationID = table.Column<decimal>(nullable: false),
                    RoleID = table.Column<decimal>(nullable: false),
                    RightID = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRightRelation", x => x.RelationID);
                    table.ForeignKey(
                        name: "FK_RoleRightRelation_Right_RightID",
                        column: x => x.RightID,
                        principalTable: "Right",
                        principalColumn: "RightID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleRightRelation_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<decimal>(nullable: false),
                    DepartmentName = table.Column<string>(maxLength: 64, nullable: false),
                    ParentDepartmentID = table.Column<decimal>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    UserID = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Department_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationLog",
                columns: table => new
                {
                    LogID = table.Column<decimal>(nullable: false),
                    OperationType = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 250, nullable: false),
                    UserID = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationLog", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_OperationLog_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleRelation",
                columns: table => new
                {
                    RelationID = table.Column<decimal>(nullable: false),
                    UserID = table.Column<decimal>(nullable: false),
                    RoleID = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleRelation", x => x.RelationID);
                    table.ForeignKey(
                        name: "FK_UserRoleRelation_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleRelation_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_UserID",
                table: "Department",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationLog_UserID",
                table: "OperationLog",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRightRelation_RightID",
                table: "RoleRightRelation",
                column: "RightID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRightRelation_RoleID",
                table: "RoleRightRelation",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRelation_RoleID",
                table: "UserRoleRelation",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRelation_UserID",
                table: "UserRoleRelation",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "OperationLog");

            migrationBuilder.DropTable(
                name: "RoleRightRelation");

            migrationBuilder.DropTable(
                name: "UserRoleRelation");

            migrationBuilder.DropTable(
                name: "Right");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
