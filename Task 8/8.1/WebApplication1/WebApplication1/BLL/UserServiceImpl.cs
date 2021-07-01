using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.BLL.Interfaces;
using WebApplication1.DAL;
using WebApplication1.Model;

namespace WebApplication1.BLL
{
    public class UserServiceImpl : IUserService
    {
        private UserJsonRepository userRepository;

        public UserServiceImpl(UserJsonRepository userJsonRepository)
        {
            this.userRepository = userJsonRepository;
        }
        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }

        public List<User> GetAllUser()
        {
            return userRepository.GetAllUsers();
        }

        public void EditUser(Guid id, string newName, DateTime newDateTime, int newAge)
        {
            userRepository.EditUser(id, newName, newDateTime, newAge);
        }

        public void DeleteUser(Guid id)
        {
            userRepository.DeleteUser(id);
        }
        public User GetUser(Guid id)
        {
            return userRepository.GetUser(id);
        }
    }
}