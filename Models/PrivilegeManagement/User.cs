using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPServer.Models.PrivilegeManagement
{
    //用户
    public class User
    {
        //用户编号
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }
        //登录名字
        [MaxLength(64), Required]
        public string LoginName { get; set; }
        [MaxLength(64), Required]
        public string Password { get; set; }
        [MaxLength(64), Required]
        public string UserName { get; set; }
        //手机号
        [MaxLength(20)]
        public string MobileNum { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        //上次登录时间
        public DateTime LastLoginTime { get; set; }
        //当前登录时间
        public DateTime CurrentLoginTime { get; set; }
        //登录次数
        [Required]
        public long LoginCount { get; set; }

        public Department Department { get; set; }
        public List<UserRoleRelation> UserRoleRelation { get; set; }

        public List<OperationLog> OperationLog { get; set; }
    }
}