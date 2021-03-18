using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Three:Barrier
    {
        public Three()
        {
            CreateLocation();
            Icon = 'д';
            Name = "Дерево";
            HealthReducer = -15;
        }
    }
}
