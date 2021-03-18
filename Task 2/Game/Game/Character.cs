using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public abstract class Character:BaseComponent
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public void RemoveTheTrail(char[,] canvas)
        {
            canvas[PositionX, PositionY] = '.';
        }
    }
}
