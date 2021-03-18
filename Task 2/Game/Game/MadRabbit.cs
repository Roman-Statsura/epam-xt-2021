using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class MadRabbit:Enemy
    {
        public MadRabbit()
        {
            PositionX = 11;
            PositionY = 0;
            Icon = '*';
            Name = "Дикий Заяц";
            Health = 10;
            Damage = 8;
        }
    }
}
