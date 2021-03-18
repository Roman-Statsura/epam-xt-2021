using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Grenade:Barrier
    {
        public Grenade()
        {
            CreateLocation();
            Icon = '@';
            Name = "Граната";
            HealthReducer = -100;
        }
    }
}
