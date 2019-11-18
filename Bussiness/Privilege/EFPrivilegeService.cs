using System.Collections.Generic;
using System.Linq;
using ERPServer.DataAccess;
using ERPServer.Models.PrivilegeManagement;
using Microsoft.EntityFrameworkCore;

namespace ERPServer.Bussiness.Privilege
{
    public class EFPrivilegeService : IPrivilegeService
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
            //this._context.Users.Include(user=>user.OperationLog)
            return this._context.Users.ToList();
        }
    }
}