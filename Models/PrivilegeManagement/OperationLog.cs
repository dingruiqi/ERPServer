using System.ComponentModel.DataAnnotations;

namespace ERPServer.Models.PrivilegeManagement
{
    public class OperationLog
    {
        //pkid
        [Key]
        public ulong LogID { get; set; }

        public int OperationType { get; set; }

        [Required, MaxLength(250)]
        public string Content { get; set; }

        public ulong UserID { get; set; }
        //操作者
        public User Operater { get; set; }
    }
}