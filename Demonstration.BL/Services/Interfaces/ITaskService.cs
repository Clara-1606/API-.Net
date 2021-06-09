using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demonstration.DAL;

namespace Demonstration.BL
{
    public interface ITaskService
    {

        //Ajouter une tâche
        TaskModel AddTask(TaskModel task);

        //Récupérer toutes les tâches
        List<TaskModel> GetAllTasks();

        //Récupérer une tâche par son id
        TaskModel GetTaskById(int id);

        //Supprimer une tâche par son id
         bool DeleteTask(int id);

        //Modifier une tâche
        TaskModel UpdateTask(int id, TaskModel task);
        
    }
}
