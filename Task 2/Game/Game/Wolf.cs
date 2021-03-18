using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Wolf:Enemy
    {
        public Wolf()
        {
            PositionX = 0;
            PositionY = 25;
            Icon = '?';
            Name = "Волчара";
            Health = 10;
            Damage = 13;
        }
    }
}
