using System;
using ERPServer.DataAccess.Configuration;
using ERPServer.Models.PrivilegeManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ERPServer.DataAccess
{
    public class PrivilegeManagementContext : DbContext
    {
        //如果在ConfigureServices中注册该上下文，则需要显示声明该构造函数，不然会报错
        public PrivilegeManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // IConfigurationRoot configuration = new ConfigurationBuilder()
            //    //.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            // var connectionString = configuration.GetConnectionString("PrivilegeDatabase").Replace("|DataDirectory|",
            // System.IO.Directory.GetCurrentDirectory() + "\\app_data\\database\\");
            // optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //种子数据必须通过EnsureCreated来添加或是直接手动输入migrate命令来生成新的迁移文件，再通过初始化方式添加
            //种子数据无法通过context.Database.Migrate()来触发添加
            // modelBuilder.Entity<User>().HasData(new User
            // {
            //     UserID = 1,
            //     LoginName = "SuperAdmin",
            //     Password = "123",
            //     UserName = "丁瑞琦",
            //     MobileNum = "13584584928",
            //     Email = "",
            //     CreateTime = DateTime.Now,
            //     LastLoginTime = DateTime.Now,
            //     CurrentLoginTime = DateTime.Now,
            //     LoginCount = 0
            // });
            //通过分散，避免在OnModelCreating写入过多的代码
            modelBuilder.ApplyConfiguration(new PrivilegeUserConfiguration());
            //modelBuilder.ApplyConfiguration(new PrivilegeDepartmentConfiguration());
        }
    }
}