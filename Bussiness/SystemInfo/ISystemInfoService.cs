using ERPServer.Models.SystemInfo;

namespace ERPServer.Bussiness.SystemInfo
{
    public interface ISystemInfoService
    {
        SystemSetInfo GetSystemInfo();

        int UpdateSystemInfo(SystemSetInfo info);

        SystemLicenseInfo GetSystemLicenseInfo();

        int SaveSystemLicenseInfo(SystemLicenseInfo licenseInfo);
    }
}