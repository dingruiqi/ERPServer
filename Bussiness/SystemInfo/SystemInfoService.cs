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

        private bool SystemInfoExists(string code)
        {
            var tmp = this.GetSystemInfo();
            return tmp != null;
        }

        public int UpdateSystemInfo(SystemSetInfo info)
        {
            //throw new System.NotImplementedException();
            //https://blog.csdn.net/xiaomifengmaidi1/article/details/102766660

            _context.SystemInfo.Update(info);
            //_context.Entry(info).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemInfoExists(info.CorporationCode))
                {
                    return -1;
                }
                else
                {
                    throw;
                }
            }
            catch (System.Exception)
            {

                throw;
            }

            return 0;
        }
    }
}