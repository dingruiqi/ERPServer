using AutoMapper;
using ERPServer.DTO.SystemInfo;
using ERPServer.Models.SystemInfo;

namespace ERPServer.DTO
{
    public class SystemInfoAutoMapperProfileConfiguration : Profile
    {
        public SystemInfoAutoMapperProfileConfiguration()
        {
            CreateMap<SystemSetInfo, SystemSetInfoDTO>();
        }
    }
}