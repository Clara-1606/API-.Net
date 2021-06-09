using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demonstration.DAL;
using Microsoft.Extensions.Logging;
using static Demonstration.DAL.TaskModel;

namespace Demonstration.BL
{
    public class TaskService : ITaskService
    {

        protected readonly DemonstrationContext _demoContext;
        private ILogger _logger;
        

        public TaskService(DemonstrationContext demoContext, ILogger<TaskService> logger)
        {
            _demoContext = demoContext;
            _logger = logger;
           
        }

        public TaskModel AddTask(TaskModel task)
        {
            try
            {
                if (task.State == StateType.Done || task.State == StateType.Todo || task.State == StateType.OnGoing) //On vérifie son state
                {
                    _demoContext.Tasks.Add(task); //On l'ajoute
                    _demoContext.SaveChanges(); //On sauvegarde dans la bdd
                }
                else
                {
                    throw new InvalidOperationException("State doesn't exist");
                }
                return task;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e); //On écrit dans les logs
                throw new Exception(e.Message, e);
            }
        }

        public bool DeleteTask(int id)
        {
            
            try
            {
                TaskModel task = _demoContext.Tasks.FirstOrDefault(x => x.Id == id); //On prend le premier élement où l'id est égale à l'id choisi
                if (task.State == StateType.Todo) //On vérifie que les statut est à faire
                {
                    _demoContext.Tasks.Remove(task);//On le supprime
                    _demoContext.SaveChanges();//On sauvegarde dans la bdd
                    return true;
                }
                else
                {
                    return false;
                }
                
               

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public List<TaskModel> GetAllTasks()
        {
            try
            {
                List<TaskModel> tasks = _demoContext.Tasks.ToList(); //On créer une liste qui affiche toutes les tâches
                return tasks;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public TaskModel GetTaskById(int id)
        {
            try
            {
                TaskModel task = _demoContext.Tasks.FirstOrDefault(x => x.Id == id); //On récupère le premier qui a l'id qui correspond
                return task;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public TaskModel UpdateTask(int id, TaskModel task)
        {
            try
            {
                TaskModel task2 = _demoContext.Tasks.FirstOrDefault(x => x.Id == id);
                task2.Title = task.Title; //On change le titre de la tâche avec celle qu'on vient de modifier
                task2.State = task.State;
                _demoContext.Tasks.Update(task2); //On applique la modification
                _demoContext.SaveChanges();
                return task2;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

    }
}
