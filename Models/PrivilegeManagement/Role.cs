using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPServer.Models.PrivilegeManagement
{
    //角色
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoleID { get; set; }

        public long ParentRoleID { get; set; }

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