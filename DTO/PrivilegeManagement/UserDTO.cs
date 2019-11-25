using System;
using System.Collections.Generic;

namespace ERPServer.DTO.PrivilegeManagement
{
    public class UserDTO
    {
        public long UserID { get; set; }
        //登录名字
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        //手机号
        public string MobileNum { get; set; }
        public string Email { get; set; }
        public DateTime CreateTime { get; set; }
        //上次登录时间
        public DateTime LastLoginTime { get; set; }
        //当前登录时间
        public DateTime CurrentLoginTime { get; set; }
        //登录次数
        public long LoginCount { get; set; }
        public DepartmentDTO Department { get; set; }
        public List<RoleDTO> Roles { get; set; }
        public List<RightDTO> Rights { get; set; }
    }
}