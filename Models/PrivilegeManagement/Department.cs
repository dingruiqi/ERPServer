using System;
using System.ComponentModel.DataAnnotations;

namespace ERPServer.Models.PrivilegeManagement
{
    public class Department
    {
        //部门ID
        [Key]
        public ulong DepartmentID { get; set; }
        [MaxLength(64), Required]
        public string DepartmentName { get; set; }

        public ulong ParentDepartmentID { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }


        //外键
        public ulong UserID { get; set; }

        public User User { get; set; }
    }
}