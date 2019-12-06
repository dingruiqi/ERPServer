using System.Diagnostics.CodeAnalysis;
using ERPServer.DataAccess.Configuration;
using ERPServer.Models.SystemInfo;
using Microsoft.EntityFrameworkCore;

namespace ERPServer.DataAccess
{
    public class SystemInfoContext : DbContext
    {
        public SystemInfoContext([NotNullAttribute] DbContextOptions<SystemInfoContext> options) : base(options)
        {
        }

        public DbSet<SystemSetInfo> SystemInfo { get; set; }

        public DbSet<SystemLicenseInfo> SystemLicenseInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SystemSetInfoConfiguration());
            modelBuilder.ApplyConfiguration(new SystemLicenseInfoConfiguration());
        }
    }
}