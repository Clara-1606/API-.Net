using AutoMapper;
using Demonstration.BL.DTO;
using Demonstration.DAL;
using Demonstration.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demonstration.BL
{
    public class UserService : IUserService
    {
        protected readonly DemonstrationContext _demoContext;
        private ILogger _logger;
        private IMapper _mapper;

        public UserService(DemonstrationContext demoContext, IMapper mapper, ILogger<UserService> logger)
        {
            _demoContext = demoContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool DeleteUser(int id)
        {

            try
            {
                User user = _demoContext.Users.Include(x => x.Tasks).FirstOrDefault(x => x.Id == id);
                _demoContext.Users.Remove(user);
                _demoContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            try
            {
                List<User> users = _demoContext.Users.Include(x => x.Tasks).ToList(); //On inclut les tâches
                List<UserDTO> userDTO = _mapper.Map<List<UserDTO>>(users); //On fait du mapping pour avoir le DTO
                return userDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public UserDTO GetUserById(int id)
        {
            try
            {
                User user = _demoContext.Users.Include(x => x.Tasks).FirstOrDefault(x => x.Id == id);
                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public User InsertUser(User user)
        {
            try
            {
                _demoContext.Users.Add(user);
                _demoContext.SaveChanges();

                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }

        public User AssociateUserWithTask(int userId, int taskId)
        {

            try
            {
                User user = _demoContext.Users.FirstOrDefault(x => x.Id == userId); //On récupère l'utilisateur
                TaskModel task = _demoContext.Tasks.FirstOrDefault(x => x.Id == taskId);//On récupère la tâche

                if (user.Tasks == null) //Si il n'y a pas de tâches associé
                {
                    user.Tasks = new List<TaskModel>(); //On créer une liste
                    user.Tasks.Add(task); //Et on ajoute la tâche
                }
                else
                {
                    user.Tasks.Add(task); //Sinon juste on ajoute la nouvelle tâche
                }

                _demoContext.Users.Update(user);
                _demoContext.SaveChanges();

                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }

        }

        public User UpdateUser(int id, User user)
        {
            try
            {
                User user2 = _demoContext.Users.FirstOrDefault(x => x.Id == id);
                user2.Username = user.Username;
                user2.Age = user.Age;
                user2.Password = user.Password;
                _demoContext.Users.Update(user2);
                _demoContext.SaveChanges();
                return user2;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new Exception(e.Message, e);
            }
        }
    }
}

