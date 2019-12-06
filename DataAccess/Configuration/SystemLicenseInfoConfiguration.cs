using ERPServer.Models.SystemInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.DataAccess.Configuration
{
    public class SystemLicenseInfoConfiguration : IEntityTypeConfiguration<SystemLicenseInfo>
    {
        public void Configure(EntityTypeBuilder<SystemLicenseInfo> builder)
        {
            //throw new System.NotImplementedException();
            builder.Property(lic => lic.Sign)
            .HasColumnType("varbinary(MAX)");

            builder.Property(lic => lic.Environment)
            .HasConversion(v => v.Encrypt(), v => v.Decrypt())
            .HasColumnType("varbinary(MAX)");
        }
    }
}