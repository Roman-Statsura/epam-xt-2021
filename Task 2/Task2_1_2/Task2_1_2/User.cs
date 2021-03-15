using System;
using System.Collections.Generic;

namespace Task2_1_2
{
    public class User
    {
        private string name;
        public List<Figure> figuresList = new List<Figure>();
        public User(string name) => this.name = name;
        public string GetName()
        {
            return name;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
