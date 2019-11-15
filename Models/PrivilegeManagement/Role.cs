using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERPServer.Models.PrivilegeManagement
{
    //角色
    public class Role
    {
        [Key]
        public ulong RoleID { get; set; }

        public ulong ParentRoleID { get; set; }

        [Required, MaxLength(64)]
        public string RoleName { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        
        public List<UserRoleRelation> UserRoleRelation { get; set; }

        public List<RoleRightRelation> RoleRightRelation { get; set; }
    }
}