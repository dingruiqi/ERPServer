using ERPServer.Models.SystemInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.DataAccess.Configuration
{
    public class SystemSetInfoConfiguration : IEntityTypeConfiguration<SystemSetInfo>
    {
        public void Configure(EntityTypeBuilder<SystemSetInfo> builder)
        {
            //throw new System.NotImplementedException();
            builder.Property(info => info.CorporationLogo)
            .HasColumnType("image");

            builder.HasData(new SystemSetInfo()
            {
                CorporationCode = "kdixgioakfgehgi"//设置公钥
            });
        }
    }
}