using System;
using System.Security.Cryptography;
using System.Text;
using ERPServer.Models.PrivilegeManagement;
using Microsoft.EntityFrameworkCore;

namespace ERPServer.DataAccess.Configuration
{
    public class PrivilegeUserConfiguration : IEntityTypeConfiguration<User>
    {
        public static string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            //throw new System.NotImplementedException();
            builder
            .Property(user => user.Password)
            .HasConversion(v => MD5Hash(v), v => v);

            builder.HasData(new User
            {
                UserID = 1,
                LoginName = "SuperAdmin",
                Password = "123456",
                UserName = "超级管理员",
                MobileNum = "",
                Email = "",
                CreateTime = DateTime.Now,
                LastLoginTime = DateTime.Now,
                CurrentLoginTime = DateTime.Now,
                LoginCount = 0
            });
        }
    }
}