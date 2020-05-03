using parking.database.Models;
using System.Collections.Generic;

namespace parking.dataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUser(int id);
        IEnumerable<User> GetAllUsers(int limit);
        User AddUser(User user);
    }
}
