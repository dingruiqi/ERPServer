using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPServer.Models.PrivilegeManagement
{
    public class Department
    {
        //部门ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DepartmentID { get; set; }
        [MaxLength(64), Required]
        public string DepartmentName { get; set; }

        public long ParentDepartmentID { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }


        //外键
        public long UserID { get; set; }

        public User User { get; set; }
    }
}