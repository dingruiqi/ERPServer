using System.ComponentModel.DataAnnotations;

namespace ERPServer.Models.PrivilegeManagement
{
    //角色权限关联表
    public class RoleRightRelation
    {
        //pkid
        [Key]
        public ulong RelationID { get; set; }

        public ulong RoleID { get; set; }
        public Role Role { get; set; }

        public ulong RightID { get; set; }
        public Right Right { get; set; }
    }
}