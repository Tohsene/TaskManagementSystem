using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Dto;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface IUserService
    {
        User CreateUser(UserDto userDto);
        User GetUserById(int userId);
        List<User> GetAllUsers();
    }
}
