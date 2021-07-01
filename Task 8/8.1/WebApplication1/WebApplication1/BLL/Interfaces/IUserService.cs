using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.BLL.Interfaces
{
    interface IUserService
    {
        void AddUser(User user);

        void DeleteUser(Guid id);

        List<User> GetAllUser();

        void EditUser(Guid id, string newName, DateTime newDateTime, int newAge);

        User GetUser(Guid id);
    }
}
