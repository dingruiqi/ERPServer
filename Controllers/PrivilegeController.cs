using System.Collections.Generic;
using ERPServer.Bussiness.Privilege;
using ERPServer.Models.PrivilegeManagement;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivilegeController : ControllerBase
    {
        private readonly IPrivilegeService _privilegeService;
        public PrivilegeController(IPrivilegeService iPrivilege)
        {
            _privilegeService = iPrivilege;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            //var temp = this._privilegeService.GetUsers();
            return this._privilegeService.GetUsers();
        }

        [HttpGet("{userID}")]
        public User GetUser(ulong userID)
        {
            return this._privilegeService.GetUser(userID);
        }
    }
}