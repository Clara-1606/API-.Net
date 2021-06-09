using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demonstration.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }

        public List<TaskModel> Tasks { get; set; }
    }
}
