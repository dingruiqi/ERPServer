using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPServer.Models.PrivilegeManagement
{
    //权限
    public class Right
    {
        //pkid
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RightID { get; set; }

        public long ParentRightID { get; set; }
        [Required, MaxLength(64)]
        public string RightName { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        public List<RoleRightRelation> RoleRightRelation { get; set; }
    }
}