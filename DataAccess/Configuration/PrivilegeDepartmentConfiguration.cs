using System;
using ERPServer.Models.PrivilegeManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPServer.DataAccess.Configuration
{
    public class PrivilegeDepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //throw new System.NotImplementedException();
            builder.HasData(new Department
            {
                DepartmentID = 1,
                DepartmentName = "超级管理员办公室",
                ParentDepartmentID = 0,
                CreateTime = DateTime.Now,
                Description = "系统超级管理员才有虚拟的部门",
                UserID = 1
            });
        }
    }
}