using System.ComponentModel.DataAnnotations;

namespace ERPServer.Models.PrivilegeManagement
{
    //用户权限关联表
    public class UserRoleRelation
    {
        //pkid
        [Key]
        public ulong RelationID { get; set; }

        public ulong UserID { get; set; }
        public User User { get; set; }

        public ulong RoleID { get; set; }
        public Role Role { get; set; }
    }
}