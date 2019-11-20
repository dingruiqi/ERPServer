using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPServer.Models.PrivilegeManagement
{
    //用户权限关联表
    public class UserRoleRelation
    {
        //pkid
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RelationID { get; set; }

        public long UserID { get; set; }
        public User User { get; set; }

        public long RoleID { get; set; }
        public Role Role { get; set; }
    }
}