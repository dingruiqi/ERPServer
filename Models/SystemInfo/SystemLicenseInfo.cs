using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERPServer.Models.SystemInfo
{
    public class SystemLicenseInfo
    {
        [Key, Required]
        public int ProductID { get; set; }
        [Required, MaxLength(64)]
        public string ProductName { get; set; }
        [Required, MaxLength(64)]
        public string OrganizationName { get; set; }
        [Required]
        public DateTime ProductLicenseStartTime { get; set; }
        [Required]
        public DateTime ProductExpireTime { get; set; }
        [Required]
        public int AuthorizedQuantity { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }

        public List<SystemModuleInfo> ModuleLicenseInfo { get; set; }
    }
}