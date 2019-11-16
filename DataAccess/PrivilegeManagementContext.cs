using ERPServer.Models.PrivilegeManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ERPServer.DataAccess
{
    public class PrivilegeManagementContext : DbContext
    {
        //如果在ConfigureServices中注册该上下文，则需要显示声明该构造函数，不然会报错
        // public PrivilegeManagementContext(DbContextOptions options) : base(options)
        // {
        // }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               //.SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("PrivilegeDatabase").Replace("|DataDirectory|",
            System.IO.Directory.GetCurrentDirectory() + "\\app_data\\database\\");
            optionsBuilder.UseSqlServer(connectionString);

            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}