using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPServer.Models.PrivilegeManagement
{
    //角色权限关联表
    public class RoleRightRelation
    {
        //pkid
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RelationID { get; set; }

        public long RoleID { get; set; }
        public Role Role { get; set; }

        public long RightID { get; set; }
        public Right Right { get; set; }
    }
}