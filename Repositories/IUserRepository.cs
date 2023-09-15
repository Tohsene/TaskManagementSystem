using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        void CreateUser(User user);
        List<User> GetAllUsers();
        User UpdateUser(int userId, User updatedUser);
        void DeleteUser(int userId);
    }
}
