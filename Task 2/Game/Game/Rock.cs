using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Rock:Barrier
    {
        public Rock()
        {
            CreateLocation();
            Icon = 'к';
            Name = "Камень";
            HealthReducer = -15;
        }
    }
}
