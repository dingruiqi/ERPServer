﻿// <auto-generated />
using System;
using ERPServer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERPServer.Migrations
{
    [DbContext(typeof(PrivilegeManagementContext))]
    [Migration("20191205085116_InitialPrivilege")]
    partial class InitialPrivilege
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.Department", b =>
                {
                    b.Property<long>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<long>("ParentDepartmentID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("DepartmentID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.OperationLog", b =>
                {
                    b.Property<long>("LogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("OperationType")
                        .HasColumnType("int");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("LogID");

                    b.HasIndex("UserID");

                    b.ToTable("OperationLog");
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.Right", b =>
                {
                    b.Property<long>("RightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<long>("ParentRightID")
                        .HasColumnType("bigint");

                    b.Property<string>("RightName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("RightID");

                    b.ToTable("Right");
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.Role", b =>
                {
                    b.Property<long>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<long>("ParentRoleID")
                        .HasColumnType("bigint");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.RoleRightRelation", b =>
                {
                    b.Property<long>("RelationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RightID")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.HasKey("RelationID");

                    b.HasIndex("RightID");

                    b.HasIndex("RoleID");

                    b.ToTable("RoleRightRelation");
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CurrentLoginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("LoginCount")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("MobileNum")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1L,
                            CreateTime = new DateTime(2019, 12, 5, 16, 51, 16, 255, DateTimeKind.Local).AddTicks(4612),
                            CurrentLoginTime = new DateTime(2019, 12, 5, 16, 51, 16, 255, DateTimeKind.Local).AddTicks(5068),
                            Email = "",
                            LastLoginTime = new DateTime(2019, 12, 5, 16, 51, 16, 255, DateTimeKind.Local).AddTicks(4861),
                            LoginCount = 0L,
                            LoginName = "SuperAdmin",
                            MobileNum = "",
                            Password = "E10ADC3949BA59ABBE56E057F20F883E",
                            UserName = "超级管理员"
                        });
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.UserRoleRelation", b =>
                {
                    b.Property<long>("RelationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("RelationID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoleRelation");
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.Department", b =>
                {
                    b.HasOne("ERPServer.Models.PrivilegeManagement.User", "User")
                        .WithOne("Department")
                        .HasForeignKey("ERPServer.Models.PrivilegeManagement.Department", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.OperationLog", b =>
                {
                    b.HasOne("ERPServer.Models.PrivilegeManagement.User", "Operater")
                        .WithMany("OperationLog")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.RoleRightRelation", b =>
                {
                    b.HasOne("ERPServer.Models.PrivilegeManagement.Right", "Right")
                        .WithMany("RoleRightRelation")
                        .HasForeignKey("RightID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERPServer.Models.PrivilegeManagement.Role", "Role")
                        .WithMany("RoleRightRelation")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERPServer.Models.PrivilegeManagement.UserRoleRelation", b =>
                {
                    b.HasOne("ERPServer.Models.PrivilegeManagement.Role", "Role")
                        .WithMany("UserRoleRelation")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERPServer.Models.PrivilegeManagement.User", "User")
                        .WithMany("UserRoleRelation")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}