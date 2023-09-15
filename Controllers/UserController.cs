using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Dto;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        // Create a new user
        [HttpPost("Create User")]
         public IActionResult CreateUser([FromBody] UserDto userDto)
          {
                try
                {
                    var user = _userService.CreateUser(userDto);
                    return CreatedAtAction(nameof(GetUserById), new { userId = user.Id }, user);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
         }

        // Update User by ID
        [HttpPut("Update User")]
        public IActionResult UpdateUser(int userId, [FromBody] User updatedUser)
        {
            try
            {
                var user = _userRepository.UpdateUser(userId, updatedUser);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete User by ID
        [HttpDelete("Delete User")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                _userRepository.DeleteUser(userId);
                return NoContent(); // 204 No Content
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Get a user by ID
        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get all users
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
