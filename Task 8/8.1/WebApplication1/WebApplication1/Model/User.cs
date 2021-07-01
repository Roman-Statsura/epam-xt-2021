using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class User
    {
        public User(string name, DateTime dateOfBirth, int age, Guid id)
        {
            ID = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Age = age;
            Awards = new List<Award>();
        }

        public Guid ID { get; private set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public void Edit(string newName, DateTime newDateOfBirth, int newAge)
        {
            Name = newName ?? throw new ArgumentNullException("str", "Name cannot be null");
            DateOfBirth = newDateOfBirth;
            Age = newAge;
        }

        public void AddAward(Award award)
        {
            Awards.Add(award);
        }

        public ICollection<Award> Awards { get; set; }

    }
}
