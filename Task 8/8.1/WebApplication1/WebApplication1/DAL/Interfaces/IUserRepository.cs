using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.DAL.Interfaces
{
    interface IUserRepository
    {
        void AddUser(User user);

        void DeleteUser(Guid id);

        void EditUser(Guid id, string newName, DateTime newDateTimeOfBirth, int newAge);

        List<User> GetAllUsers();

        User GetUser(Guid id);
    }
}
