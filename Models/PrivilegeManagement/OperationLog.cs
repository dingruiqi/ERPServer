using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPServer.Models.PrivilegeManagement
{
    public class OperationLog
    {
        //pkid
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogID { get; set; }

        public int OperationType { get; set; }

        [Required, MaxLength(250)]
        public string Content { get; set; }

        public long UserID { get; set; }
        //操作者
        public User Operater { get; set; }
    }
}