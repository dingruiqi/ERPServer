namespace ERPServer.DTO.SystemInfo
{
    public class SystemSetInfoDTO
    {
        //产品公钥，初始化时写入
        public string CorporationCode { get; set; }

        public string CorporationName { get; set; }

        public string CorporationAddress { get; set; }

        public string WebAddress { get; set; }

        public byte[] CorporationLogo { get; set; }
    }
}