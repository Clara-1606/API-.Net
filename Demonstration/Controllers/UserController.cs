using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demonstration.BL;
using Demonstration.BL.DTO;
using Demonstration.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demonstration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<UserDTO> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        // GET api/<UserController>
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            return _userService.GetUserById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public User Post(User user)
        {
            return _userService.InsertUser(user);
        }

        // PUT api/<UserController>
        [HttpPut("{id}")]
        public User Put(int id, User user)
        {
            return _userService.UpdateUser(id, user);
        }

        // DELETE api/<UserController>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _userService.DeleteUser(id);
        }

        [HttpPost("AssociateUserWithTask")]
        public User AssociateUserWithTask(int userId, int taskId)
        {
            return _userService.AssociateUserWithTask(userId, taskId);
        }
    }
}
