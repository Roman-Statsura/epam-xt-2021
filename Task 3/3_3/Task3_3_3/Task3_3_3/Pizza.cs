using System;
using System.Collections.Generic;
using System.Text;

namespace Task3_3_3
{
    public class Pizza
    {
        public TypeOfPizza Name { get; set; }
        public int CokingTime { get; set; }
        public Pizza(TypeOfPizza name,int time)
        {
            Name = name;
            CokingTime = time;
        }
    }
}
