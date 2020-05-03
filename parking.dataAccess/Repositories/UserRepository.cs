using parking.database.Models;
using parking.dataAccess.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace parking.dataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly MyWebApiContext _dbContext;
        public UserRepository(MyWebApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.User;
        }

        public IEnumerable<User> GetAllUsers(int limit)
        {
            return _dbContext.User.OrderByDescending(x => x.signUpDate).Take(limit);
        }

        public User GetUser(int id)
        {
            return _dbContext.User.SingleOrDefault(x => x.id == id);
        }
        public User AddUser(User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

    }
}
