using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.DAL.Interfaces;
using WebApplication1.Model;

namespace WebApplication1.DAL
{
    public class UserJsonRepository : IUserRepository
    {
        private const string PATH = @"C:\Users\srs10\edu\epam-xt-2021\Task 8\8.1\WebApplication1\WebApplication1\localstorage\users\";

        public void AddUser(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            File.WriteAllText(GetPathToUserFile(user.ID), json);
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            var files = Directory.GetFiles(PATH, "*.json");
            foreach (var file in files)
            {
                var str = File.ReadAllText(file);
                User user = JsonConvert.DeserializeObject<User>(str);
                users.Add(user);
            }
            return users;
        }

        public void DeleteUser(Guid id)
        {
            if (File.Exists(GetPathToUserFile(id)))
                File.Delete(GetPathToUserFile(id));
            else
                throw new FileNotFoundException("User with ID - " + id + " not found!");
        }

        public void EditUser(Guid id, string newName, DateTime newDateTimeOfBirth, int newAge)
        {
            if (!File.Exists(GetPathToUserFile(id)))
            {
                throw new FileNotFoundException("User with ID - " + id + " not found!");
            }

            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(GetPathToUserFile(id)));
            user.Edit(newName, newDateTimeOfBirth, newAge);
            File.WriteAllText(GetPathToUserFile(id), JsonConvert.SerializeObject(user));
        }
        public User GetUser(Guid id)
        {
            if (!File.Exists(GetPathToUserFile(id)))
            {
                throw new FileNotFoundException("User with ID - " + id + " not found!");
            }
            var str = File.ReadAllText(GetPathToUserFile(id));
            User user = JsonConvert.DeserializeObject<User>(str);
            
            return user;
        }
        private string GetPathToUserFile(Guid id)
        {
            return PATH + id + ".json";
        }
    }
}