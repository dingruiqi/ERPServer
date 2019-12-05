using System.Collections.Generic;
using ERPServer.Models.PrivilegeManagement;

namespace ERPServer.Bussiness.Privilege
{
    public interface IPrivilegeService
    {
        List<User> GetUsers();

        User GetUser(long userID);

        int AddUser(User user);

        int UpdateUser(User user);
    }
}