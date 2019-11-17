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
        private readonly IPrivilege _privilegeService;
        public PrivilegeManagementController(IPrivilege iPrivilege)
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