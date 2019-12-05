using System.Linq;
using ERPServer.DataAccess;
using ERPServer.Models.SystemInfo;
using Microsoft.EntityFrameworkCore;

namespace ERPServer.Bussiness.SystemInfo
{
    public class SystemInfoService : ISystemInfoService
    {
        private readonly SystemInfoContext _context;

        public SystemInfoService(SystemInfoContext context)
        {
            //注入
            this._context = context;
        }

        public SystemSetInfo GetSystemInfo()
        {
            //throw new System.NotImplementedException();
            return this._context.SystemInfo.AsNoTracking()
            .ToList().FirstOrDefault();
        }

        public SystemLicenseInfo GetSystemLicenseInfo()
        {
            throw new System.NotImplementedException();
        }

        public int SaveSystemLicenseInfo(SystemLicenseInfo licenseInfo)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateSystemInfo(SystemSetInfo info)
        {
            throw new System.NotImplementedException();
        }
    }
}