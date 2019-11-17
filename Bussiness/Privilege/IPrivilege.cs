using System.Collections.Generic;
using ERPServer.Models.PrivilegeManagement;

namespace ERPServer.Bussiness.Privilege
{
    public interface IPrivilege
    {
        List<User> GetUsers();

        User GetUser(int userID);
    }
}