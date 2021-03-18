using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Coin:BaseComponent
    {
        public int Denomination { get; private set; }
        public Coin()
        {
            CreateLocation();
            Icon = '$';
            Name = "Монета";
        }
    }
}
