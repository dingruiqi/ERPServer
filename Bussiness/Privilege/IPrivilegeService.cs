using System.Collections.Generic;
using ERPServer.Models.PrivilegeManagement;

namespace ERPServer.Bussiness.Privilege
{
    public interface IPrivilegeService
    {
        List<User> GetUsers();

        User GetUser(ulong userID);
    }
}