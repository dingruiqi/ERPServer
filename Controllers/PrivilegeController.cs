using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ERPServer.Bussiness.Privilege;
using ERPServer.DTO;
using ERPServer.DTO.PrivilegeManagement;
using ERPServer.Models.PrivilegeManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERPServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivilegeController : ControllerBase
    {
        private readonly IPrivilegeService _privilegeService;

        private readonly ILogger<PrivilegeController> _logger;

        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public PrivilegeController(IPrivilegeService iPrivilege, ILogger<PrivilegeController> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _privilegeService = iPrivilege;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("auth")]
        public Result Authenticate([FromBody]AuthenticationInfo authInfo)
        {
            Result res = new Result();

            try
            {
                if (authInfo.UserName == null || authInfo.Password == null)
                {
                    res.State = 1;
                    res.Message = "验证信息不合法";
                }
                else
                {
                    var user = this._privilegeService.GetUsers()
                    .Find(user => user.LoginName == authInfo.UserName
                    && user.Password.ToUpper() == authInfo.Password.ToUpper());
                    
                    if (user == null)
                    {
                        res.State = 2;
                        res.Message = "当前用户不合法";
                    }
                    else
                    {
                        res.Data = _mapper.Map<UserDTO>(user);
                        res.Message = "当前用户验证成功";
                    }
                }
            }
            catch (System.Exception e)
            {
                _logger.LogError("验证用户失败：{0}", e.Message);

                res.Data = e;
                res.State = -1;
                //throw;
            }

            return res;
        }

        [HttpGet]
        [Route("user")]
        public Result GetUsers()
        {
            Result res = new Result();

            try
            {
                var temp = this._privilegeService.GetUsers();
                res.Data = _mapper.Map<List<UserDTO>>(temp);
            }
            catch (System.Exception e)
            {
                _logger.LogError("查询用户失败：{0}", e.Message);

                res.Data = e;
                res.State = 1;
                //throw;
            }
            return res;
        }

        [HttpGet]
        [Route("user/{userID}")]
        public Result GetUser(long userID)
        {
            Result res = new Result();
            try
            {
                var temp = this._privilegeService.GetUser(userID);

                res.Data = _mapper.Map<UserDTO>(temp);
                //res.Data = this._privilegeService.GetUser(userID);

                if (res.Data == null)
                {
                    res.State = -1;
                    res.Message = $"不存在当前用户-{userID}";
                }
            }
            catch (System.Exception e)
            {
                _logger.LogError("查询用户{0}失败：{1}", userID, e.Message);

                res.Data = e;
                res.State = 1;
                //throw;
            }

            return res;
        }

        [HttpPut]
        [Route("user")]
        public Result UpdateUser([FromBody]User user)
        {
            Result res = new Result();

            return res;
        }

        [HttpPost]
        [Route("user")]
        public Result AddUser([FromBody]User user)
        {
            Result res = new Result();

            try
            {
                res.State = this._privilegeService.AddUser(user);
                if (res.State != 0)
                {
                    res.Message = "当前已经存在相同编号的用户！";
                    res.Data = user;
                }
                else
                {
                    _logger.LogInformation("新增用户{0}-{1}", user.UserID, user.UserName);
                }
            }
            catch (System.Exception e)
            {
                if (e is DbUpdateException)
                {
                    res.State = 1;
                    res.Message = $"更新数据库失败！{e.Message}";
                    res.Data = e;
                }
                else
                {
                    res.State = 2;
                    res.Message = $"发生未知异常！{e.Message}";
                    res.Data = e;
                }

                _logger.LogError("添加用户{0}失败：{1}", user.UserName, e.Message);
                //throw;
            }


            return res;
        }
    }
}