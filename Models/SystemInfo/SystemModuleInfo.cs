using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPServer.Models.SystemInfo
{
    public class SystemModuleInfo
    {
        [Key, Required]
        public int ModuleID { get; set; }
        [Required, MaxLength(64)]
        public string ModuleName { get; set; }
        [Required]
        public DateTime ModuleLicenseStartTime { get; set; }
        [Required]
        public DateTime ModuleExpireTime { get; set; }

        public int ProductID { get; set; }
        //[ForeignKey("ProductID")]
        public SystemLicenseInfo LicenseInfo { get; set; }
    }
}