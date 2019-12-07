using AutoMapper;
using ERPServer.Bussiness.SystemInfo;
using ERPServer.DTO;
using ERPServer.DTO.SystemInfo;
using ERPServer.Models.SystemInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERPServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SystemInfoController : ControllerBase
    {
        private readonly ISystemInfoService _systemInfoService;

        private readonly ILogger<SystemInfoController> _logger;

        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public SystemInfoController(ISystemInfoService iSystemInfo, ILogger<SystemInfoController> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _systemInfoService = iSystemInfo;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPut]
        public Result UpdateSystemInfo([FromBody]SystemSetInfoDTO systemInfo)
        {
            Result res = new Result();

            try
            {
                var temp = _mapper.Map<SystemSetInfo>(systemInfo);
                res.State = _systemInfoService.UpdateSystemInfo(temp);
                if (res.State != 0)
                {
                    res.Message = "数据库中不存在对应的系统！";
                    res.Data = systemInfo.CorporationCode;
                }
            }
            catch (System.Exception e)
            {
                res.State = 1;
                res.Message = $"更新系统信息失败！{e.Message}";
                res.Data = e;

                _logger.LogError("更新系统信息失败：{0}", e.Message);
                //throw;
            }

            return res;
        }

        [HttpGet]
        public Result GetSystemInfo()
        {
            Result res = new Result();

            try
            {
                var temp = this._systemInfoService.GetSystemInfo();

                res.Data = _mapper.Map<SystemSetInfoDTO>(temp);
            }
            catch (System.Exception e)
            {
                res.State = 1;
                res.Message = $"获取系统信息失败！{e.Message}";
                res.Data = e;

                _logger.LogError("获取系统信息失败：{0}", e.Message);
                //throw;
            }

            return res;
        }
    }
}