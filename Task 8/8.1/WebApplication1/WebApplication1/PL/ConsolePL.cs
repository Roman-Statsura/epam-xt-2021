using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.BLL;
using WebApplication1.DAL;
using WebApplication1.Model;

namespace WebApplication1.PL
{
    public class ConsolePL
    {
        static void Main(string[] args)
        {
            var dal = new UserJsonRepository();
            var bll = new UserServiceImpl(dal);

            bll.AddUser(new User("Roman", DateTime.Parse("1998.12.10"), 22, Guid.NewGuid()));
            bll.AddUser(new User("Oleg", DateTime.Parse("1964.1.9"), 27, Guid.NewGuid()));

            var list =  bll.GetAllUser();

            Console.WriteLine(list.Count);
        }
    }
}