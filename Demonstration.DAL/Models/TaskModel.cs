using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demonstration.DAL
{
    public class TaskModel
    {
        public enum StateType
        {
            Todo,
            OnGoing,
            Done
        }
        public int Id { get; set; }
        public string Title { get; set; }
        
        public StateType State { get;set; }
    }
}
