using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demonstration.DAL;

namespace Demonstration.BL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }

        public List<TaskModel> Tasks { get; set; }
    }
}
