using System.ComponentModel.DataAnnotations;

namespace ERPServer.Models.SystemInfo
{
    public class SystemSetInfo
    {
        //产品公钥，初始化时写入
        [Key, Required]
        public string CorporationCode { get; set; }
        [MaxLength(64)]
        public string CorporationName { get; set; }
        //expiredTime: Date;
        [MaxLength(64)]
        public string CorporationAddress { get; set; }
        [MaxLength(64)]
        public string WebAddress { get; set; }

        public byte[] CorporationLogo { get; set; }
    }
}