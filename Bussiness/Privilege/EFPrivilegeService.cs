using System.Collections.Generic;
using System.Linq;
using ERPServer.DataAccess;
using ERPServer.Models.PrivilegeManagement;

namespace ERPServer.Bussiness.Privilege
{
    public class EFPrivilegeService : IPrivilege
    {
        private readonly PrivilegeManagementContext _context;

        public EFPrivilegeService(PrivilegeManagementContext context)
        {
            //注入
            this._context = context;
        }

        public User GetUser(int userID)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetUsers()
        {
            //throw new System.NotImplementedException();
            return this._context.Users.ToList();
        }
    }
}