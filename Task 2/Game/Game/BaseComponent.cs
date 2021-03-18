using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public abstract class BaseComponent
    {
        public string Name { get; protected set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public char Icon { get; set; }
        protected void CreateLocation()
        {
            Random rnd = new Random();
            PositionX = rnd.Next(1, 11);
            PositionY = rnd.Next(1, 25);
        }
    }
}
