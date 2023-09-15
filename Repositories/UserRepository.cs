using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }
        // Update User by ID
        public User UpdateUser(int userId, User updatedUser)
        {
            var existingUser = _context.Users.Find(userId);

            if (existingUser == null)
            {
                throw new NotFoundException("User not found"); // You can create this custom exception class.
            }

            // Update user properties
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;

            _context.SaveChanges();

            return existingUser;
        }

        // Delete User by ID
        public void DeleteUser(int userId)
        {
            var userToDelete = _context.Users.Find(userId);

            if (userToDelete == null)
            {
                throw new NotFoundException("User not found");
            }

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }
    }
}
