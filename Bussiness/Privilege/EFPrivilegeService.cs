using System;
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

        public int AddUser(User user)
        {
            //throw new System.NotImplementedException();
            this._context.Users.Add(user);

            try
            {
                this._context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserID))
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

        private bool UserExists(long userID)
        {
            //throw new NotImplementedException();
            var tmp = this.GetUser(userID);
            return tmp != null;
        }

        public User GetUser(long userID)
        {
            //throw new System.NotImplementedException();
            return this._context.Users
            .Include(user => user.Department)
            .Include(user => user.UserRoleRelation)
                .ThenInclude(userRoleRelation => userRoleRelation.Role)
                .ThenInclude(role => role.RoleRightRelation)
                .ThenInclude(roleRightRelation => roleRightRelation.Right)
            .AsNoTracking()
            .SingleOrDefault(t => t.UserID == userID);
        }

        public List<User> GetUsers()
        {
            //throw new System.NotImplementedException();
            //this._context.Users.Include(user=>user.OperationLog)
            return this._context.Users
            .AsNoTracking()
            .ToList();
        }

        public int UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}