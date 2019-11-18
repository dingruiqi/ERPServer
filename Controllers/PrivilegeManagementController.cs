using System.Collections.Generic;
using ERPServer.Bussiness.Privilege;
using ERPServer.Models.PrivilegeManagement;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivilegeManagementController : ControllerBase
    {
        private readonly IPrivilegeService _privilegeService;
        public PrivilegeManagementController(IPrivilegeService iPrivilege)
        {
            _privilegeService = iPrivilege;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            //var temp = this._privilegeService.GetUsers();
            return this._privilegeService.GetUsers();
        }
    }
}