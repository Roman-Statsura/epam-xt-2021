using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Award
    {
        public Award(string title, Guid id)
        {
            ID = id;
            Title = title;
            Users = new List<User>();
        }

        public Guid ID { get; private set; }

        public string Title { get; set; }

        public void AddAward(User user)
        {
            Users.Add(user);
        }

        public ICollection<User> Users { get; set; }
    }
}