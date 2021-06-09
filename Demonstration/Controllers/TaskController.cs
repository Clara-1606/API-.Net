using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demonstration.BL;
using Demonstration.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Demonstration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController
    {
        private ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public List<TaskModel> GetAllTasks()
        {
            return _taskService.GetAllTasks();
        }

        // GET api/<TaskController>
        [HttpGet("{id}")]
        public TaskModel Get(int id)
        {
            return _taskService.GetTaskById(id);
        }

        // POST api/<TaskController>
        [HttpPost]
        public TaskModel Post(TaskModel task)
        {
            return _taskService.AddTask(task);
        }

        // PUT api/<TaskController>
        [HttpPut("{id}")]
        public TaskModel Put(int id, TaskModel task)
        {
            return _taskService.UpdateTask(id, task);
        }

        // DELETE api/<TaskController>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _taskService.DeleteTask(id);
        }
    }
}
