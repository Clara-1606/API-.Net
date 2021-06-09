using Demonstration.BL.DTO;
using Demonstration.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demonstration.BL
{
    public interface IUserService
    {
        //Récupère tous les utilisateurs
        public List<UserDTO> GetAllUsers();

        //Récupère un utilisateur par son id
        public UserDTO GetUserById(int id);

        //Supprimer un utilisateur avec son id
        public bool DeleteUser(int id);

        //Ajouter un utlisateur
        public User InsertUser(User user);

        //Associer un utilisateur à une tâche
        public User AssociateUserWithTask(int userId, int taskId);

        //Modifier un utilisateur
        public User UpdateUser(int id, User user);
    }
}
